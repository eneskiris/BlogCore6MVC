using Entities.Concrete;

namespace Business.Abstract;

public interface IWriterService : IGenericService<Writer>
{
    List<Writer> GetWriterListById(int id);
}