using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;
public class WriterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }    
    public IActionResult WriterProfile()
    {
        return View();
    }    

}