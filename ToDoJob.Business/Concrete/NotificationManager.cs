using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Business.Interfaces;
using ToDoJob.DataAccess.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification table)
        {
            _notificationDal.Add(table);
        }

        public void Delete(Notification table)
        {
            _notificationDal.Delete(table);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> GetUnread(int AppUserId)
        {
            return _notificationDal.GetUnread(AppUserId);
        }

        public int GetUnreadCountWithAppUserId(int AppUserId)
        {
            return _notificationDal.GetUnreadCountWithAppUserId(AppUserId);
        }

        public void Update(Notification table)
        {
            _notificationDal.Update(table);
        }
    }
}
