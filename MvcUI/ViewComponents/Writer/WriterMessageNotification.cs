using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Writer;

public class WriterMessageNotification : ViewComponent
{
    MessageManager messageManager = new MessageManager(new EfMessageRepository());
    public IViewComponentResult Invoke()
    {
        string email = "eneskiris@gmail.com";
        var values = messageManager.GetListInboxByWriter(email);
        return View(values);
    }
}