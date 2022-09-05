using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IBlogDal
{
    List<Blog> ListAllBlog();
    void AddBlog(Blog blog);
    void DeleteBlog(Blog blog);
    void UpdateBlog(Blog blog);
    Blog GetById(int id);
}