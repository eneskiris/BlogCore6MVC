using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class AdminManager : IAdminService
{
    IAdminDal _adminDal;

    public AdminManager(IAdminDal adminDal)
    {
        _adminDal = adminDal;
    }

    public void Add(Admin entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Admin entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Admin entity)
    {
        throw new NotImplementedException();
    }

    public List<Admin> GetList()
    {
        return _adminDal.GetAll();
    }

    public Admin GetById(int id)
    {
        throw new NotImplementedException();
    }
}