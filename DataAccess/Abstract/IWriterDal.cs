using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IWriterDal : IGenericDal<Writer>
{
    Writer GetWriterByEmail(string email);
}