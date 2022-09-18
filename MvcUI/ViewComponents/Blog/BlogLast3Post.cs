using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Blog;

public class BlogLast3Post : ViewComponent
{
    private IBlogService _blogService;

    public BlogLast3Post(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _blogService.GetList().Take(3).ToList();
        return View(values);
    }
}