using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcUI.Controllers;

[AllowAnonymous]
public class BlogController : Controller
{
    private IBlogService _blogService;
    private ICategoryService _categoryService;
    private BlogValidator blogValidator = new BlogValidator();
    private ValidationResult validationResult = new ValidationResult();

    public BlogController(IBlogService blogService, ICategoryService categoryService)
    {
        _blogService = blogService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var values = _blogService.GetListWithCategory();
        return View(values);
    }

    public IActionResult ReadAll(int id)
    {
        ViewBag.Id = id;
        var values = _blogService.GetBlogListById(id);
        return View(values);
    }

    public IActionResult BlogListByWriter()
    {
        var values = _blogService.GetListWithCategoryByWriter(1);
        return View(values);
    }

    [HttpGet]
    public IActionResult BlogAdd()
    {
        CategoryValues();
        return View();
    }

    [HttpPost]
    public IActionResult BlogAdd(Blog blog)
    {
        validationResult = blogValidator.Validate(blog);
        if (validationResult.IsValid)
        {
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.Status = true;
            blog.WriterId = 1;
            _blogService.Add(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        foreach (var item in validationResult.Errors)
        {
            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }

        return View();
    }

    public IActionResult Delete(int id)
    {
        var value = _blogService.GetById(id);
        _blogService.Delete(value);
        return RedirectToAction("BlogListByWriter", "Blog");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        CategoryValues();
        var value = _blogService.GetById(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult Update(Blog blog)
    {
        validationResult = blogValidator.Validate(blog);
        if (validationResult.IsValid)
        {
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.Status = true;
            blog.WriterId = 1;
            _blogService.Update(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        foreach (var item in validationResult.Errors)
        {
            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }

        return View();
    }

    private void CategoryValues()
    {
        List<SelectListItem> categoryvalues = (from x in _categoryService.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
        ViewBag.CategoryValues = categoryvalues;
    }
}