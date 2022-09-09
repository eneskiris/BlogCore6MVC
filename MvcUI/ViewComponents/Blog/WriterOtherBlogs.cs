using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcUI.ViewComponents.Blog;

public class WriterOtherBlogs : ViewComponent
{
    private BlogManager _blogManager = new BlogManager(new EfBlogRepository());

    public IViewComponentResult Invoke()
    {
        var values = _blogManager.GetBlogByWriter(1);
        return View(values);
    }
}