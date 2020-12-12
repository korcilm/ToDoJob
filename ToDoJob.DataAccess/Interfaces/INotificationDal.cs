using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Interfaces
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        List<Notification> GetUnread(int AppUserId);
        int GetUnreadCountWithAppUserId(int AppUserId);
    }
}
