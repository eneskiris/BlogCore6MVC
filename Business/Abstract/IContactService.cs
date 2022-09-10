using Entities.Concrete;

namespace Business.Abstract;

public interface IContactService
{
    void ContactAdd(Contact contact);
}