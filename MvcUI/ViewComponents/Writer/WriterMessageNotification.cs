using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Writer;

public class WriterMessageNotification : ViewComponent
{
    private IMessageWithWriterService _messageWithWriterService;

    public WriterMessageNotification(IMessageWithWriterService messageWithWriterService)
    {
        _messageWithWriterService = messageWithWriterService;
    }

    public IViewComponentResult Invoke()
    {
        int id = 2;
        var values = _messageWithWriterService.GetInboxListByWriter(id);
        return View(values);
    }
}