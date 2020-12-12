using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoJob.DataAccess.Concrete.EntityFramework.Contexts;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetUnread(int AppUserId)
        {
            using var context= new ToDoJobContext();
            return context.Notifications.Where(I => I.AppUserId == AppUserId && !I.State).ToList();
        }

        public int GetUnreadCountWithAppUserId(int AppUserId)
        {
            using var context = new ToDoJobContext();
            return context.Notifications.Count(I => I.AppUserId == AppUserId && !I.State);

        }
    }
}
