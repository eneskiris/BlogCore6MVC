using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class WriterController : Controller
{
    private IWriterService _writerService;

    public WriterController(IWriterService writerService)
    {
        _writerService = writerService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddWriter(Writer writer)
    {
        _writerService.Add(writer);
        var jsonWriters = JsonConvert.SerializeObject(writer);
        return Json(jsonWriters);
    }

    public IActionResult DeleteWriter(int writerId)
    {
        var writerToDelete = _writerService.GetById(writerId);
        _writerService.Delete(writerToDelete);
        return Json(writerToDelete);
    }
    
    [HttpPost]
    public IActionResult UpdateWriter(Writer writer)
    {
        _writerService.Update(writer);
        var jsonWriter = JsonConvert.SerializeObject(writer);
        return Json(jsonWriter);
    }
    public IActionResult WriterList()
    {
        var getAll = _writerService.GetList();
        var jsonWriters = JsonConvert.SerializeObject(getAll);
        return Json(jsonWriters);
    }
    
    public IActionResult GetWriterById(int writerId)
    {
        var writer = _writerService.GetById(writerId);
        var jsonWriter = JsonConvert.SerializeObject(writer);
        return Json(jsonWriter);
    }
}