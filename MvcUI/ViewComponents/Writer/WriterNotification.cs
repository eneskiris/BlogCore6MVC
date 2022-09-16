using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Writer;

public class WriterNotification : ViewComponent
{
    NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());
    public IViewComponentResult Invoke()
    {
        var values = notificationManager.GetList();
        return View(values);
    }
}