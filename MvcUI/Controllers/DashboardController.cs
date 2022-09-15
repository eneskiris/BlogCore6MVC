using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class DashboardController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        BlogDemoContext context = new BlogDemoContext();
        ViewBag.BlogsCount = context.Blogs.Count();
        ViewBag.WriterBlogsCount = context.Blogs.Count(x => x.WriterId == 1);
        ViewBag.CategoriesCount = context.Categories.Count();
        
        return View();
    }
}