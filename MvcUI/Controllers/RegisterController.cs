using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class RegisterController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(Writer writer)
    {
        return RedirectToAction("Index", "Blog");
    }
}