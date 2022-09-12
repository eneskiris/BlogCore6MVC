using Entities.Concrete;

namespace Business.Abstract;

public interface IBlogService : IGenericService<Blog>
{
    List<Blog> GetListWithCategory();
    List<Blog> GetBlogListById(int id);
    List<Blog> GetBlogByWriter(int id);
}