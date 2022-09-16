using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class NotificationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}