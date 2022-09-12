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

    public void Add(About entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(About entity)
    {
        throw new NotImplementedException();
    }

    public void Update(About entity)
    {
        throw new NotImplementedException();
    }

    public List<About> GetList()
    {
        return _aboutDal.GetAll();
    }

    public About GetById(int id)
    {
        throw new NotImplementedException();
    }
}