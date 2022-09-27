using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;
[AllowAnonymous]
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
    
    public IActionResult MessageDetails(int id)
    {
       var value = _messageWithWriterService.GetById(id);
        return View(value);
    }
}