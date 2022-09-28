using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBlogController : Controller
{
    private IBlogService _blogService;

    public AdminBlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public IActionResult Index()
    {
        var values = _blogService.GetListWithCategory();
        return View(values);
    }
}