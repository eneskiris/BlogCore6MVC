using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private EfCategoryRepository _efCategoryRepository;

    public CategoryManager()
    {
        _efCategoryRepository = new EfCategoryRepository();
    }

    public void CategoryAdd(Category category)
    {
        _efCategoryRepository.Insert(category);
    }

    public void CategoryDelete(Category category)
    {
        _efCategoryRepository.Delete(category);
    }

    public void CategoryUpdate(Category category)
    {
        _efCategoryRepository.Update(category);
    }

    public List<Category> GetList()
    {
        return _efCategoryRepository.GettAll();
    }

    public Category GetById(int id)
    {
        return _efCategoryRepository.GetById(id);
    }
}