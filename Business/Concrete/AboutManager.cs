using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class AboutManager : IAboutService
{
    private IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public List<About> GetList()
    {
        return _aboutDal.GetAll();
    }
}