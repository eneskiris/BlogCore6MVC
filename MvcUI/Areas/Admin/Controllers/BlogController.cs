using ClosedXML.Excel;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Areas.Admin.Models;

namespace MvcUI.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController : Controller
{
    // GET
    public IActionResult ExportExcelBlogList()
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Blog List");
            worksheet.Cell(1, 1).Value = "Blog Id";
            worksheet.Cell(1, 2).Value = "Blog Title";

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
        List<BlogModel> blogModels = new List<BlogModel>();
        using (var context = new BlogDemoContext())
        {
            blogModels = context.Blogs.Select(x => new BlogModel
            {
                Id = x.BlogId,
                BlogName = x.Title
            }).ToList();
        }
        return blogModels;
    }
    
    public IActionResult BlogListExcel()
    {
        return View();
    }
}