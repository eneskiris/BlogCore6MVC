using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class MessageWithWriterManager : IMessageWithWriterService
{
    private IMessageWithWriterDal _messageWithWriterDal;

    public MessageWithWriterManager(IMessageWithWriterDal messageWithWriterDal)
    {
        _messageWithWriterDal = messageWithWriterDal;
    }

    public void Add(MessageWithWriter entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(MessageWithWriter entity)
    {
        throw new NotImplementedException();
    }

    public void Update(MessageWithWriter entity)
    {
        throw new NotImplementedException();
    }

    public List<MessageWithWriter> GetList()
    {
        return _messageWithWriterDal.GetAll();
    }

    public MessageWithWriter GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<MessageWithWriter> GetInboxListByWriter(int id)
    {
        return _messageWithWriterDal.GetListWithMessageByWriter(id);
    }
}