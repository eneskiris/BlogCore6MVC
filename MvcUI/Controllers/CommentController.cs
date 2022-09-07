using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class CommentController : Controller
{
    CommentManager _commentManager = new CommentManager(new EfCommentRepository());
    // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }

    public PartialViewResult PartialAddComment()
    {
        return PartialView();
    }    
    public PartialViewResult PartialCommentList(int id)
    {
        var values = _commentManager.GetListByBlogId(id);
        return PartialView(values);
    }
}