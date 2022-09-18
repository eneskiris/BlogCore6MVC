using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcUI.ViewComponents.Blog;

public class WriterOtherBlogs : ViewComponent
{
    private IBlogService _blogService;

    public WriterOtherBlogs(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _blogService.GetBlogByWriter(1);
        return View(values);
    }
}