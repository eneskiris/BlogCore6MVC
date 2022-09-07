using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public void CategoryAdd(Category category)
    {
        _categoryDal.Insert(category);
    }

    public void CategoryDelete(Category category)
    {
        _categoryDal.Delete(category);
    }

    public void CategoryUpdate(Category category)
    {
        _categoryDal.Update(category);
    }

    public List<Category> GetList()
    {
        return _categoryDal.GetAll();
    }

    public Category GetById(int id)
    {
        return _categoryDal.GetById(id);
    }
}