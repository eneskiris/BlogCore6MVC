using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;
[AllowAnonymous]
public class MessageController : Controller
{
    private IMessageWithWriterService _messageWithWriterService;
    // GET
    public MessageController(IMessageWithWriterService messageWithWriterService)
    {
        _messageWithWriterService = messageWithWriterService;
    }

    public IActionResult Inbox()
    {
        int id = 2;
        var values = _messageWithWriterService.GetInboxListByWriter(id);
        return View(values);
    }
    
    public IActionResult MessageDetails(int id)
    {
       var value = _messageWithWriterService.GetById(id);
        return View(value);
    }
}