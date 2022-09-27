using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;
public class MessageController : Controller
{
    private IMessageWithWriterService _messageWithWriterService;

    private IWriterService _writerService;
    // GET
    public MessageController(IMessageWithWriterService messageWithWriterService, IWriterService writerService)
    {
        _messageWithWriterService = messageWithWriterService;
        _writerService = writerService;
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
    
    public IActionResult MessageDetails(int id)
    {
       var value = _messageWithWriterService.GetById(id);
        return View(value);
    }

    [HttpGet]
    public IActionResult SendMessage()
    {
        return View();
    }    
    
    [HttpPost]
    public IActionResult SendMessage(MessageWithWriter message)
    {
        var writerId = _writerService.GetWriterByEmail(User.Identity.Name).WriterId;
        message.SenderId = writerId;
        message.ReceiverId = 2;
        message.Status = true;
        message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        _messageWithWriterService.Add(message);
        return RedirectToAction("Inbox", "Message");
    }
}