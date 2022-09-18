using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
        var values = _writerService.GetWriterListById(1);
        return View(values);
    }
}