using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Blog;

public class BlogListDashboard : ViewComponent
{
    private BlogManager _blogManager = new BlogManager(new EfBlogRepository());

    public IViewComponentResult Invoke()
    {
        var values = _blogManager.GetListWithCategory();
        return View(values);
    }
}