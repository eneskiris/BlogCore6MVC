using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class ContactController : Controller
{
    ContactManager _contactManager = new ContactManager(new EfContactRepository());
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
        _contactManager.ContactAdd(contact);
        return RedirectToAction("Index", "Blog");
    }

}