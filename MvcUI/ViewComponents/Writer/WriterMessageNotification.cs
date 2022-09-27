using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Writer;

public class WriterMessageNotification : ViewComponent
{
    private IMessageWithWriterService _messageWithWriterService;
    private IWriterService _writerService;

    public WriterMessageNotification(IMessageWithWriterService messageWithWriterService, IWriterService writerService)
    {
        _messageWithWriterService = messageWithWriterService;
        _writerService = writerService;
    }

    public IViewComponentResult Invoke()
    {
        var writerId = _writerService.GetWriterByEmail(User.Identity.Name).WriterId;
        var values = _messageWithWriterService.GetInboxListByWriter(writerId);
        return View(values);
    }
}