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
    public void Add(Blog entity)
    {
        _blogDal.Insert(entity);
    }

    public void Delete(Blog entity)
    {
        _blogDal.Delete(entity);
    }

    public void Update(Blog entity)
    {
        _blogDal.Update(entity);
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

    public List<Blog> GetBlogListById(int id)
    {
        return _blogDal.GetAll(x => x.BlogId == id);
    }

    public List<Blog> GetBlogByWriter(int id)
    {
        return _blogDal.GetAll(x=>x.WriterId == id);
    }
}