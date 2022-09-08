using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class RegisterController : Controller
{
    WriterManager _writerManager = new WriterManager(new EfWriterRepository());

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Writer writer)
    {
        writer.Status = true;
        writer.About = "Test";
        _writerManager.WriterAdd(writer);
        return RedirectToAction("Index", "Blog");
    }
}