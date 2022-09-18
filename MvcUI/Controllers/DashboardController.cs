using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class DashboardController : Controller
{
    private ICategoryService _categoryService;
    private IBlogService _blogService;

    public DashboardController(ICategoryService categoryService, IBlogService blogService)
    {
        _categoryService = categoryService;
        _blogService = blogService;
    }

    public IActionResult Index()
    {
        ViewBag.BlogsCount = _blogService.GetList().Count;
        ViewBag.WriterBlogsCount = _blogService.GetList().Count(x => x.WriterId == 1);
        ViewBag.CategoriesCount = _categoryService.GetList().Count;
        
        return View();
    }
}