using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class NotificationController : Controller
{
    NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult AllNotifications()
    {
        var values = _notificationManager.GetList();
        return View(values);
    }
}