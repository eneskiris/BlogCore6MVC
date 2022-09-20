using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Areas.Admin.ViewComponents.Statistics;

public class Statistics : ViewComponent
{
    private IBlogService _blogService;
    private IMessageService _messageService;
    private ICommentService _commentService;

    public Statistics(IBlogService blogService, ICommentService commentService, IMessageService messageService)
    {
        _blogService = blogService;
        _commentService = commentService;
        _messageService = messageService;
    }

    public IViewComponentResult Invoke()
    {
        ViewBag.BlogsCount = _blogService.GetList().Count();
        ViewBag.MessagesCount = _messageService.GetList().Count();
        ViewBag.CommentCount = _commentService.GetList().Count();
        return View();
    }
}