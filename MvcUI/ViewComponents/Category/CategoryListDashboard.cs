using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Category;

public class CategoryListDashboard : ViewComponent
{
    private CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
    public IViewComponentResult Invoke(int id)
    {
        var values = _categoryManager.GetList();
        return View(values);
    }
}