using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Blog;

public class BlogListDashboard : ViewComponent
{
    private IBlogService _blogService;

    public BlogListDashboard(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _blogService.GetListWithCategory();
        return View(values);
    }
}