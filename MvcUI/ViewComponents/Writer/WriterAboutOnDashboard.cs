using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.ViewComponents.Writer;

public class WriterAboutOnDashboard : ViewComponent
{
    WriterManager _writerManager = new WriterManager(new EfWriterRepository());
    public IViewComponentResult Invoke()
    {
        var values = _writerManager.GetWriterListById(1);
        return View(values);
    }
}