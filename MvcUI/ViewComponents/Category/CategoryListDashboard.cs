using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Category;

public class CategoryListDashboard : ViewComponent
{
    private ICategoryService _categoryService;

    public CategoryListDashboard(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public IViewComponentResult Invoke(int id)
    {
        var values = _categoryService.GetList();
        return View(values);
    }
}