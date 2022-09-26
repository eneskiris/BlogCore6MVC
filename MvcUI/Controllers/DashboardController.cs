using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class DashboardController : Controller
{
    private ICategoryService _categoryService;
    private IBlogService _blogService;
    private IWriterService _writerService;

    public DashboardController(ICategoryService categoryService, IBlogService blogService, IWriterService writerService)
    {
        _categoryService = categoryService;
        _blogService = blogService;
        _writerService = writerService;
    }

    public IActionResult Index()
    {
        var writers = _writerService.GetList();
        var email = User.Identity.Name;
        var writerId = writers.Where(x=> x.Email == email).Select(y=>y.WriterId).FirstOrDefault(); 
        ViewBag.BlogsCount = _blogService.GetList().Count;
        ViewBag.WriterBlogsCount = _blogService.GetList().Count(x => x.WriterId == writerId);
        
        ViewBag.CategoriesCount = _categoryService.GetList().Count;
        
        return View();
    }
}