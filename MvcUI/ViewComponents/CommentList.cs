using Microsoft.AspNetCore.Mvc;
using MvcUI.Models;

namespace MvcUI.ViewComponents;

public class CommentList : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var commentValues = new List<UserComment>()
        {
            new UserComment()
            {
                Id = 1,
                UserName = "enes"
            },
            new UserComment()
            {
                Id = 2,
                UserName = "Enes"
            }
        };
        return View(commentValues);
    }
}