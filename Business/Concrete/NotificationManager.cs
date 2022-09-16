using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class NotificationManager : INotificationService
{
    INotificationDal _notificationDal;

    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }

    public void Add(Notification entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Notification entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Notification entity)
    {
        throw new NotImplementedException();
    }

    public List<Notification> GetList()
    {
        return _notificationDal.GetAll();
    }

    public Notification GetById(int id)
    {
        throw new NotImplementedException();
    }
}