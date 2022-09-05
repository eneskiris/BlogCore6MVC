using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace DataAccess.Repositories;

public class CategoryRepository : ICategoryDal
{
    private BlogDemoContext _blogDemoContext = new();

    public List<Category> ListAllCategory()
    {
        return _blogDemoContext.Categories.ToList();
    }

    public void AddCategory(Category category)
    {
        _blogDemoContext.Add(category);
        _blogDemoContext.SaveChanges();
    }

    public void DeleteCategory(Category category)
    {
        _blogDemoContext.Remove(category);
        _blogDemoContext.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        _blogDemoContext.Update(category);
        _blogDemoContext.SaveChanges();
    }

    public Category GetById(int id)
    {
        return _blogDemoContext.Categories.Find(id);
    }
}