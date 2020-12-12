using System;
using System.Collections.Generic;
using System.Text;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Business.Interfaces
{
    public interface INotificationService:IGenericService<Notification>
    {
        List<Notification> GetUnread(int AppUserId);
        int GetUnreadCountWithAppUserId(int AppUserId);
    }
}
