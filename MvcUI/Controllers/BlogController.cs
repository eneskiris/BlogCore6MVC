using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class BlogController : Controller
{
    private BlogManager _blogManager = new BlogManager(new EfBlogRepository());
    public IActionResult Index()
    {
        var values = _blogManager.GetListWithCategory();
        return View(values);
    }
}