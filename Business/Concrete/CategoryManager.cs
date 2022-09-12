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
    public void Add(Category entity)
    {
        _categoryDal.Insert(entity);
    }

    public void Delete(Category entity)
    {
        _categoryDal.Delete(entity);
    }

    public void Update(Category entity)
    {
        _categoryDal.Update(entity);
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