using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfBlogRepository : GenericRepository<Blog>,IBlogDal
{
    
}