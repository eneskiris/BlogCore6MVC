using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ContactManager : IContactService
{
    private IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void ContactAdd(Contact contact)
    {
        _contactDal.Insert(contact);
    }
}