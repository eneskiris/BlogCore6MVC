using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Blog;

public class BlogLast3Post : ViewComponent
{
    private BlogManager _blogManager = new BlogManager(new EfBlogRepository());

    public IViewComponentResult Invoke()
    {
        var values = _blogManager.GetList().Take(3).ToList();
        return View(values);
    }
}