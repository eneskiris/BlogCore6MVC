using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace DataAccess.Repositories;

public class BlogRepository : IBlogDal
{
    public List<Blog> ListAllBlog()
    {
        using var context = new BlogDemoContext();
        return context.Blogs.ToList();
    }

    public void AddBlog(Blog blog)
    {
        using var context = new BlogDemoContext();
        context.Add(blog);
        context.SaveChanges();
    }

    public void DeleteBlog(Blog blog)
    {
        using var context = new BlogDemoContext();
        context.Remove(blog);
        context.SaveChanges();
    }

    public void UpdateBlog(Blog blog)
    {
        using var context = new BlogDemoContext();
        context.Update(blog);
        context.SaveChanges();
    }

    public void Insert(Blog entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Blog entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Blog entity)
    {
        throw new NotImplementedException();
    }

    public List<Blog> GettAll()
    {
        throw new NotImplementedException();
    }

    public Blog GetById(int id)
    {
        using var context = new BlogDemoContext();
        return context.Blogs.Find(id);
    }
}