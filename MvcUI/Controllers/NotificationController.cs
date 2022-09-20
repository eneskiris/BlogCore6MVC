using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class NotificationController : Controller
{
    INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    [AllowAnonymous]
    public IActionResult AllNotifications()
    {
        var values = _notificationService.GetList();
        return View(values);
    }
}