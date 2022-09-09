using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class NewsLetterManager : INewsLetterService
{
    private INewsLetterDal _newsLetterDal;

    public NewsLetterManager(INewsLetterDal newsLetterDal)
    {
        _newsLetterDal = newsLetterDal;
    }

    public void AddNewsLetter(NewsLetter newsLetter)
    {
        _newsLetterDal.Insert(newsLetter);
    }
}