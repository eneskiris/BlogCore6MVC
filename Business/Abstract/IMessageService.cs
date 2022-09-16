using Entities.Concrete;

namespace Business.Abstract;

public interface IMessageService : IGenericService<Message>
{
    List<Message> GetListInboxByWriter(string parameter);
}