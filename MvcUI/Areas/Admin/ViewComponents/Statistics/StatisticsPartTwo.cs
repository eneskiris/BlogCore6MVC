using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Areas.Admin.ViewComponents.Statistics;

public class StatisticsPartTwo : ViewComponent
{
    private IBlogService _blogService;

    public StatisticsPartTwo(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public IViewComponentResult Invoke()
    {
        var lastBlog = _blogService.GetList().TakeLast(1).FirstOrDefault();
        ViewBag.LastBlog = lastBlog.Title;
        return View();
    }
}