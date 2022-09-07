using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Comment;

public class CommentListByBlog : ViewComponent
{
    private CommentManager _commentManager = new CommentManager(new EfCommentRepository());
    public IViewComponentResult Invoke()
    {
        var values = _commentManager.GetListByBlogId(4);
        return View(values);
    }
}