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

    public void WriterAdd(Writer writer)
    {
        _writerDal.Insert(writer);
    }
}