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

    public void Insert(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Category entity)
    {
        throw new NotImplementedException();
    }

    public List<Category> GettAll()
    {
        throw new NotImplementedException();
    }

    public Category GetById(int id)
    {
        return _blogDemoContext.Categories.Find(id);
    }
}