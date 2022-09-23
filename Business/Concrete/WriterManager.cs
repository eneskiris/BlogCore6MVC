using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class WriterManager : IWriterService
{
    IWriterDal _writerDal;

    public WriterManager(IWriterDal writerDal)
    {
        _writerDal = writerDal;
    }

    public void Add(Writer entity)
    {
        _writerDal.Insert(entity);
    }

    public void Delete(Writer entity)
    {
        _writerDal.Delete(entity);
    }

    public void Update(Writer entity)
    {
        _writerDal.Update(entity);
    }

    public List<Writer> GetList()
    {
        return _writerDal.GetAll();
    }

    public Writer GetById(int id)
    {
        return _writerDal.GetById(id);
    }

    public List<Writer> GetWriterListById(int id)
    {
        return _writerDal.GetAll(x => x.WriterId == id);
    }

    public Writer GetWriterByEmail(string email)
    {
        return _writerDal.GetWriterByEmail(email);
    }
}