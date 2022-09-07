using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class CommentController : Controller
{
    // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }

    public PartialViewResult PartialAddComment()
    {
        return PartialView();
    }    
    public PartialViewResult PartialCommentList()
    {
        return PartialView();
    }
}