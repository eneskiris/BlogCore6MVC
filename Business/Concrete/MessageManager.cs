using System.Linq.Expressions;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class MessageManager : IMessageService
{
    private IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }


    public void Add(Message entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Message entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Message entity)
    {
        throw new NotImplementedException();
    }

    public List<Message> GetList()
    {
        throw new NotImplementedException();
    }

    public Message GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Message> GetListInboxByWriter(string parameter)
    {
        return _messageDal.GetAll(x => x.Receiver == parameter);
    }
}