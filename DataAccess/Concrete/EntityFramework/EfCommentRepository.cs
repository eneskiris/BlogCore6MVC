using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCommentRepository : GenericRepository<Comment>,ICommentDal
{
    public List<Comment> GetListWithBlog()
    {
        using (var context = new BlogDemoContext())
        {
            return context.Comments.Include(x=>x.Blog).ToList();
        }
    }
}