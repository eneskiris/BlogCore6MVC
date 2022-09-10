using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class AboutController : Controller
{
    private AboutManager _aboutManager = new AboutManager(new EfAboutRepository());
    
    public IActionResult Index()
    {
        var values = _aboutManager.GetList();
        return View(values);
    }
    public PartialViewResult SocialMedia()
    {
        return PartialView();
    }
}