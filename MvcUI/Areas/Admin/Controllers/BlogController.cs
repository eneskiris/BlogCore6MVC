using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Areas.Admin.Models;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController : Controller
{
    // GET
    public IActionResult ExportStaticExcelBlogList()
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Blog List");
            worksheet.Cell(1, 1).Value = "Blog Id";
            worksheet.Cell(1, 2).Value = "Blog Name";

            int blogRowCount = 2;
            foreach (var item in GetBlogList())
            {
                worksheet.Cell(blogRowCount, 1).Value = item.Id;
                worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
                blogRowCount++;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "BlogList.xlsx");
            }
        }
    }

    public List<BlogModel> GetBlogList()
    {
        List<BlogModel> blogModels = new List<BlogModel>
        {
            new BlogModel { Id = 1, BlogName = "C# Programlamaya Girişi" },
            new BlogModel { Id = 2, BlogName = "Tesla Elektrikli Arabaları" },
            new BlogModel { Id = 3, BlogName = "2022 Yılında Yapılacak Olan Yeni Oyunlar" },
        };
        return blogModels;
    }
    
    public IActionResult BlogListExcel()
    {
        return View();
    }
}