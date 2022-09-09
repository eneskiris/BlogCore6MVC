using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}