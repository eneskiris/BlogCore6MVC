using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public PartialViewResult AdminNavbarPartial()
    {
        return PartialView();
    }
}