using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Writer;

public class WriterAboutOnDashboard : ViewComponent
{
    private IWriterService _writerService;

    public WriterAboutOnDashboard(IWriterService writerService)
    {
        _writerService = writerService;
    }

    public IViewComponentResult Invoke()
    {
        var writer= _writerService.GetWriterByEmail(User.Identity.Name);
        return View(writer);
    }
}