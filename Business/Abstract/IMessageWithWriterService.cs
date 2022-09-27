using Entities.Concrete;

namespace Business.Abstract;

public interface IMessageWithWriterService : IGenericService<MessageWithWriter>
{
    List<MessageWithWriter> GetInboxListByWriter(int id);
    List<MessageWithWriter> GetSendBoxListByWriter(int id);
}