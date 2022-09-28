using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminCommentController : Controller
{
    private ICommentService _commentService;

    public AdminCommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public IActionResult Index()
    {
        var comments = _commentService.GetListWithBlog();
        return View(comments);
    }
}