using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class BlogController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}