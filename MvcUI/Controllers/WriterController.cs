using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
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

    [AllowAnonymous, HttpGet]
    public IActionResult WriterEditProfile()
    {
        var values = _writerManager.GetById(1);
        return View(values);
    }    
    [AllowAnonymous, HttpPost]
    public IActionResult WriterEditProfile(Writer writer)
    {
        WriterValidator validator = new WriterValidator();
        ValidationResult result = validator.Validate(writer);
        if (result.IsValid)
        {
            writer.Status = true;
            _writerManager.Update(writer);
            return RedirectToAction("Index", "Dashboard");
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();
    }
}