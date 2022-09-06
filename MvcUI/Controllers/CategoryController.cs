using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class CategoryController : Controller
{
    private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
    public IActionResult Index()
    {
        var getList = _categoryManager.GetList();
        return View(getList);
    }
}