using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminMessageController : Controller
{
    // GET
    public IActionResult Inbox()
    {
        return View();
    }
}