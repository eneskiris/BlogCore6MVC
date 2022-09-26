using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcUI.Controllers;

public class BlogController : Controller
{
    private IBlogService _blogService;
    private ICategoryService _categoryService;
    private IWriterService _writerService;
    private BlogValidator blogValidator = new();
    private ValidationResult validationResult = new();

    public BlogController(IBlogService blogService, ICategoryService categoryService, IWriterService writerService)
    {
        _blogService = blogService;
        _categoryService = categoryService;
        _writerService = writerService;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var values = _blogService.GetListWithCategory();
        return View(values);
    }

    [AllowAnonymous]
    public IActionResult ReadAll(int id)
    {
        ViewBag.Id = id;
        var values = _blogService.GetBlogListById(id);
        return View(values);
    }

    public IActionResult BlogListByWriter()
    {
        var writer = _writerService.GetWriterByEmail(User.Identity.Name).WriterId;
        var bloglistbywriter = _blogService.GetListWithCategoryByWriter(writer);
        return View(bloglistbywriter);
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
            blog.WriterId = _writerService.GetWriterByEmail(User.Identity.Name).WriterId;
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
            blog.WriterId = _writerService.GetWriterByEmail(User.Identity.Name).WriterId;
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