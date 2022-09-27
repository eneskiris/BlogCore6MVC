using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IMessageWithWriterDal : IGenericDal<MessageWithWriter>
{
    List<MessageWithWriter> GetInboxListByWriter(int id);
    List<MessageWithWriter> GetSendBoxListByWriter(int id);

}