using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class CommentController : Controller
{
    private ICommentService _commentService;
    // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

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
        _commentService.CommentAdd(comment);
        return PartialView();
    }    
    public PartialViewResult PartialCommentList(int id)
    {
        var values = _commentService.GetListByBlogId(id);
        return PartialView(values);
    }
}