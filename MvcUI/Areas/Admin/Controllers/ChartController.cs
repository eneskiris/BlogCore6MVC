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
        categoryCharts.Add(new CategoryChart { categoryname = "Game", categorycount = 12 });        
        categoryCharts.Add(new CategoryChart { categoryname = "Software", categorycount = 14 });        
        categoryCharts.Add(new CategoryChart { categoryname = "Sports", categorycount = 5 });
        return Json(new {jsonlist = categoryCharts});
    }
}