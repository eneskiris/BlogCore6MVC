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
        _messageWithWriterDal.Insert(entity);
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
        return _messageWithWriterDal.GetById(id);
    }

    public List<MessageWithWriter> GetInboxListByWriter(int id)
    {
        return _messageWithWriterDal.GetInboxListByWriter(id);
    }

    public List<MessageWithWriter> GetSendBoxListByWriter(int id)
    {
        return _messageWithWriterDal.GetSendBoxListByWriter(id);
    }
}