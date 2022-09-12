using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Writer;

public class WriterNotification : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}