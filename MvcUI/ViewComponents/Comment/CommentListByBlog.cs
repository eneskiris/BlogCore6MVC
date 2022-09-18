using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Comment;

public class CommentListByBlog : ViewComponent
{
    private ICommentService _commentService;

    public CommentListByBlog(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public IViewComponentResult Invoke(int id)
    {
        var values = _commentService.GetListByBlogId(id);
        return View(values);
    }
}