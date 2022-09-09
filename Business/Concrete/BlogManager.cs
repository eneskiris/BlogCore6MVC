using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BlogManager : IBlogService
{
    private IBlogDal _blogDal;

    public BlogManager(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }

    public void BlogAdd(Blog blog)
    {
        _blogDal.Insert(blog);
    }

    public void BlogDelete(Blog blog)
    {
        _blogDal.Delete(blog);
    }

    public void BlogUpdate(Blog blog)
    {
        _blogDal.Update(blog);
    }

    public List<Blog> GetList()
    {
        return _blogDal.GetAll();
    }

    public Blog GetById(int id)
    {
        return _blogDal.GetById(id);
    }
    
    public List<Blog> GetListWithCategory()
    {
        return _blogDal.GetListWithCategory();
    }

    public List<Blog> GetBlogById(int id)
    {
        return _blogDal.GetAll(x => x.BlogId == id);
    }

    public List<Blog> GetBlogByWriter(int id)
    {
        return _blogDal.GetAll(x=>x.WriterId == id);
    }
}