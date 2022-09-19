using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int page = 1)
        {
            var values = _categoryService.GetList().ToPagedList(page, 5);
            return View(values);
        }
    }
}