using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class ErrorPage : Controller
{
    // GET
    public IActionResult Error404(int statusCode)
    {
        return View();
    }
}