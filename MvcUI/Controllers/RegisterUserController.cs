using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Models;

namespace MvcUI.Controllers;

[AllowAnonymous]
public class RegisterUserController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterUserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }    
    
    [HttpPost]
    public async Task<IActionResult> Index(UserSignUpViewModel user)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = new AppUser
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName
            };
            
            var result = await _userManager.CreateAsync(appUser, user.Password);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View();
    }
}