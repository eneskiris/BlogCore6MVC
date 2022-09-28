using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminMessageController : Controller
{
    private IWriterService _writerService;
    private IMessageWithWriterService _messageWithWriterService;

    public AdminMessageController(IWriterService writerService, IMessageWithWriterService messageWithWriterService)
    {
        _writerService = writerService;
        _messageWithWriterService = messageWithWriterService;
    }

    public IActionResult Inbox()
    {
        var writerId = _writerService.GetWriterByEmail(User.Identity.Name).WriterId;
        var values = _messageWithWriterService.GetInboxListByWriter(writerId);
        return View(values);
    }
    
    public IActionResult SendBox()
    {
        var writerId = _writerService.GetWriterByEmail(User.Identity.Name).WriterId;
        var values = _messageWithWriterService.GetSendBoxListByWriter(writerId);
        return View(values);
    }

    [HttpGet]
    public IActionResult ComposeMessage()
    {
        return View();
    }    
    
    [HttpPost]
    public IActionResult ComposeMessage(MessageWithWriter message)
    {
        var writerId = _writerService.GetWriterByEmail(User.Identity.Name).WriterId;
        var values = _messageWithWriterService.GetSendBoxListByWriter(writerId);
        message.SenderId = writerId;
        message.ReceiverId = 2;
        message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        message.Status = true;
        _messageWithWriterService.Add(message);
        return RedirectToAction("SendBox");
    }
}