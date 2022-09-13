using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IBlogDal:IGenericDal<Blog>
{
    List<Blog> GetListWithCategory();
    List<Blog> GetListWithCategoryByWriter(int id);
}