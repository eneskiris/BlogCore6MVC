using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;
[AllowAnonymous]
public class BlogController : Controller
{
    private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
    public IActionResult Index()
    {
        var values = _blogManager.GetListWithCategory();
        return View(values);
    }

    public IActionResult ReadAll(int id)
    {
        ViewBag.Id = id;
        var values = _blogManager.GetBlogListById(id);
        return View(values);
    }
    
    public IActionResult BlogListByWriter()
    {
        var values = _blogManager.GetBlogByWriter(1);
        return View(values);
    }
}