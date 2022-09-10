using System.Security.Claims;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
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
    public async Task<IActionResult>  Index(Writer writer)
    {
        BlogDemoContext _blogDemoContext = new BlogDemoContext();
        var datavalue = _blogDemoContext.Writers.FirstOrDefault(x=>x.Email == writer.Email && x.Password == writer.Password);
        if (datavalue!=null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, writer.Email)
            };
            var useridentity = new ClaimsIdentity(claims,"a");
            ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
            await HttpContext.SignInAsync(principal);
            return RedirectToAction("Index", "Writer");
        }
        return View();
    }
}