using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class LoginController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Index(Writer writer)
    {
        BlogDemoContext _blogDemoContext = new BlogDemoContext();
        var datavalue =
            _blogDemoContext.Writers.FirstOrDefault(x => x.Email == writer.Email && x.Password == writer.Password);
        if (datavalue != null)
        {
            HttpContext.Session.SetString("username", writer.Email);
            return RedirectToAction("Index", "Writer");
        }
        return View();
    }
}