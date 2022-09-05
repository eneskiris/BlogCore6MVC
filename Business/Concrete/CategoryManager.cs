using Business.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private CategoryRepository _categoryRepository = new();

    public void CategoryAdd(Category category)
    {
        if (category.CategoryName != "" && category.Description != "" && category.CategoryName.Length >= 5 &&
            category.Status == true)
        {
            _categoryRepository.AddCategory(category);
        }
        else
        {
            //Hata mesajı
        }
    }

    public void CategoryDelete(Category category)
    {
        throw new NotImplementedException();
    }

    public void CategoryUpdate(Category category)
    {
        throw new NotImplementedException();
    }

    public List<Category> GetList()
    {
        throw new NotImplementedException();
    }

    public Category GetById(int id)
    {
        throw new NotImplementedException();
    }
}