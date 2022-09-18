using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class RegisterController : Controller
{
    IWriterService _writerService;

    public RegisterController(IWriterService writerService)
    {
        _writerService = writerService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Writer writer)
    {
        WriterValidator writerValidator = new WriterValidator();
        ValidationResult validationResult = writerValidator.Validate(writer);
        if (validationResult.IsValid)
        {
            writer.Status = true;
            writer.About = "Test";
            _writerService.Add(writer);
            return RedirectToAction("Index", "Blog");
        }

        foreach (var item in validationResult.Errors)
        {
            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }

        return View();
    }
}