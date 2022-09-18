using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class ContactController : Controller
{
    private IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }    
    [HttpPost]
    public IActionResult Index(Contact contact)
    {
        contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
        contact.Status = true;
        _contactService.ContactAdd(contact);
        return RedirectToAction("Index", "Blog");
    }

}