using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Areas.Admin.ViewComponents.Statistics;

public class StatisticsPartFour : ViewComponent
{
    private IAdminService _adminService;

    public StatisticsPartFour(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public IViewComponentResult Invoke()
    {
        var admin = _adminService.GetList().Take(1).FirstOrDefault();
        ViewBag.AdminFullName = admin.FullName;
        ViewBag.AdminImage = admin.ImageURL;
        ViewBag.AdminDescription = admin.Description;
        return View();
    }
}