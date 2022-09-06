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
        return _blogDal.GettAll();
    }

    public Blog GetById(int id)
    {
        return _blogDal.GetById(id);
    }
}