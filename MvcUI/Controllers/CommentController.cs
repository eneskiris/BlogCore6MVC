using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
    [HttpGet]
    public PartialViewResult PartialAddComment()
    {
        return PartialView();
    }      
    [HttpPost]
    public PartialViewResult PartialAddComment(Comment comment)
    {
        comment.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
        comment.Status = true;
        comment.BlogId = 2; 
        _commentManager.CommentAdd(comment);
        return PartialView();
    }    
    public PartialViewResult PartialCommentList(int id)
    {
        var values = _commentManager.GetListByBlogId(id);
        return PartialView(values);
    }
}