using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}