using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Writer;

public class WriterNotification : ViewComponent
{
    private INotificationService _notificationService;

    public WriterNotification(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _notificationService.GetList();
        return View(values);
    }
}