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
    private BlogManager _blogManager = new BlogManager(new EfBlogRepository());

    public IActionResult Index()
    {
        var values = _blogManager.GetListWithCategory();
        return View(values);
    }

    public IActionResult ReadAll(int id)
    {
        ViewBag.Id = id;
        var values = _blogManager.GetBlogListById(id);
        return View(values);
    }

    public IActionResult BlogListByWriter()
    {
        var values = _blogManager.GetBlogByWriter(1);
        return View(values);
    }

    [HttpGet]
    public IActionResult BlogAdd()
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        List<SelectListItem> categoryvalues = (from x in _categoryManager.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
        ViewBag.CategoryValues = categoryvalues;
        return View();
    }

    [HttpPost]
    public IActionResult BlogAdd(Blog blog)
    {
        BlogValidator blogValidator = new BlogValidator();
        ValidationResult validationResult = blogValidator.Validate(blog);
        if (validationResult.IsValid)
        {
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.Status = true;
            blog.WriterId = 1;
            _blogManager.Add(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        foreach (var item in validationResult.Errors)
        {
            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }

        return View();
    }
}