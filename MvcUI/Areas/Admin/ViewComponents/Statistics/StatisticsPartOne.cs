using System.Xml.Linq;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Areas.Admin.ViewComponents.Statistics;

public class StatisticsPartOne : ViewComponent
{
    private IBlogService _blogService;
    private IMessageService _messageService;
    private ICommentService _commentService;

    public StatisticsPartOne(IBlogService blogService, ICommentService commentService, IMessageService messageService)
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
        
        string apiKey = "55bae1403626b66bc18e2e5cd5af55ab";
        string connection = "https://api.openweathermap.org/data/2.5/weather?q=izmir&mode=xml&units=metric&appid=" + apiKey;
        XDocument document = XDocument.Load(connection);
        
        ViewBag.City= document.Descendants("city").Attributes("name").FirstOrDefault().Value;
        ViewBag.Forecast = document.Descendants("temperature").Attributes("value").FirstOrDefault().Value;
        return View();
    }
}