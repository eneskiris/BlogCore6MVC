using Microsoft.AspNetCore.Mvc;
using MvcUI.Areas.Admin.Models;
using Newtonsoft.Json;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class WriterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult WriterList()
    {
        var jsonWriters = JsonConvert.SerializeObject(writers);
        return Json(jsonWriters);
    }
    
    public static List<WriterModel> writers = new List<WriterModel>
    {
        new WriterModel
        {
            Id = 1,
            FullName = "Ahmet Yılmaz",
        },
        new WriterModel
        {
            Id = 2,
            FullName = "Mehmet Bal",
        },
        new WriterModel
        {
            Id = 3,
            FullName = "Ayşe Sönmez",
        },
    };
    
    public IActionResult GetWriterById(int writerId)
    {
        var writer = writers.FirstOrDefault(x => x.Id == writerId);
        var jsonWriter = JsonConvert.SerializeObject(writer);
        return Json(jsonWriter);
    }
}