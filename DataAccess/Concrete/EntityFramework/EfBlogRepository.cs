using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
{
    public List<Blog> GetListWithCategory()
    {
        using (var _context = new BlogDemoContext())
        {
            return _context.Blogs.Include(x => x.Category).ToList();
        }
    }

    public List<Blog> GetListWithCategoryByWriter(int id)
    {
        using (var _context = new BlogDemoContext())
        {
            return _context.Blogs.Include(x => x.Category).Where(x=>x.WriterId == id).ToList();
        }
    }
}