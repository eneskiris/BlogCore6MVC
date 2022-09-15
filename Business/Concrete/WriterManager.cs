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
        throw new NotImplementedException();
    }

    public void Update(Writer entity)
    {
        throw new NotImplementedException();
    }

    public List<Writer> GetList()
    {
        throw new NotImplementedException();
    }

    public Writer GetById(int id)
    {
        return _writerDal.GetById(id);
    }

    public List<Writer> GetWriterListById(int id)
    {
        return _writerDal.GetAll(x => x.WriterId == id);
    }
}