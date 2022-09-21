using Microsoft.AspNetCore.Mvc;
using MvcUI.Areas.Admin.Models;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ChartController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CategoryChart()
    {
        List<CategoryChart> categoryCharts = new List<CategoryChart>();
        categoryCharts.Add(new CategoryChart { CategoryName = "Game", CategoryCount = 12 });        
        categoryCharts.Add(new CategoryChart { CategoryName = "Software", CategoryCount = 14 });        
        categoryCharts.Add(new CategoryChart { CategoryName = "Sports", CategoryCount = 5 });
        return Json(new {jsonlist = categoryCharts});
    }
}