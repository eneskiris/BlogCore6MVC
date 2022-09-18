using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers;

public class NewsLetterController : Controller
{
    INewsLetterService _newsLetterService;

    public NewsLetterController(INewsLetterService newsLetterService)
    {
        _newsLetterService = newsLetterService;
    }

    [HttpGet]
    public PartialViewResult SubscribeMail()
    {
        return PartialView();
    }
    
    [HttpPost]
    public PartialViewResult SubscribeMail(NewsLetter newsLetter)
    {
        newsLetter.Status = true;
        _newsLetterService.AddNewsLetter(newsLetter);
        return PartialView();
    }
}