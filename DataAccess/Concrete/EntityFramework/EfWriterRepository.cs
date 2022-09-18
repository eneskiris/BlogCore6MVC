using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfWriterRepository : GenericRepository<Writer>,IWriterDal
{
    public Writer GetWriterByEmail(string email)
    {
        using (BlogDemoContext context = new BlogDemoContext())
        {
            return context.Writers.FirstOrDefault(x => x.Email == email);
        }    
    }
}