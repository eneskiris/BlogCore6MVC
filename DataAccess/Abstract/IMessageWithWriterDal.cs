using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IMessageWithWriterDal : IGenericDal<MessageWithWriter>
{
    List<MessageWithWriter> GetListWithMessageByWriter(int id);

}