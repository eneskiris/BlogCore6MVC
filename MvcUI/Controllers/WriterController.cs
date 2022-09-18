using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Models;

namespace MvcUI.Controllers;

public class WriterController : Controller
{
    IWriterService _writerService;

    public WriterController(IWriterService writerService)
    {
        _writerService = writerService;
    }

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
        var values = _writerService.GetById(1);
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
            _writerService.Update(writer);
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

    [AllowAnonymous, HttpGet]
    public IActionResult WriterAdd()
    {
        return View();
    }

    [AllowAnonymous, HttpPost]
    public IActionResult WriterAdd(Writer writer, IFormFile image)
    {
        var extension = Path.GetExtension(image.FileName);
        var randomName = Guid.NewGuid() + extension;
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", randomName);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            image.CopyTo(stream);
        }

        writer.Image = randomName;
        writer.Status = true;
        _writerService.Add(writer);
        return RedirectToAction("Index", "Dashboard");
    }
}