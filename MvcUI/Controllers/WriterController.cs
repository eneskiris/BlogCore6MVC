using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;
public class WriterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }    
    public IActionResult WriterProfile()
    {
        return View();
    }    

}