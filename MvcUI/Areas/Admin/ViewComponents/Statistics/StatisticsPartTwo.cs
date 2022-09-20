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
        ViewBag.LastBlog = _blogService.GetList().TakeLast(1).FirstOrDefault().Title;
        return View();
    }
}