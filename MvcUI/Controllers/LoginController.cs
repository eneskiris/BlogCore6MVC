using System.Security.Claims;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Models;

namespace MvcUI.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    // private readonly SignInManager<AppUser> _signInManager;
    // public LoginController(SignInManager<AppUser> signInManager)
    // {
    //     _signInManager = signInManager;
    // }
    // [HttpPost]
    // public async Task<IActionResult> Index(UserSignInViewModel user)
    // {
    //     if (!ModelState.IsValid) return View();
    //     var result = await _signInManager.PasswordSignInAsync(user.username, user.password, false, true);
    //     return RedirectToAction("Index", result.Succeeded ? "Dashboard" : "Login");
    // }


    private IWriterService _writerService;
    
    public LoginController(IWriterService writerService)
    {
        _writerService = writerService;
    }
    [HttpPost]
    public async Task<IActionResult>  Index(Writer writer)
    {
        var datavalue = _writerService.GetList().FirstOrDefault(x=>x.Email == writer.Email && x.Password == writer.Password);
        if (datavalue!=null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, writer.Email)
            };
            var useridentity = new ClaimsIdentity(claims,"a");
            ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
            await HttpContext.SignInAsync(principal);
            return RedirectToAction("Index", "Dashboard");
        }
        return View();
    }
}