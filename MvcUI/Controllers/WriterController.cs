using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;
public class WriterController : Controller
{
    WriterManager _writerManager = new WriterManager(new EfWriterRepository());
    public IActionResult Index()
    {
        return View();
    }    
    public IActionResult WriterProfile()
    {
        return View();
    }

    public PartialViewResult WriterNavbarPartial()
    {
        return PartialView();
    }    
    public PartialViewResult WriterFooterPartial()
    {
        return PartialView();
    }

    [AllowAnonymous]
    public IActionResult WriterEditProfile()
    {
        var values = _writerManager.GetById(1);
        return View(values);
    }
}