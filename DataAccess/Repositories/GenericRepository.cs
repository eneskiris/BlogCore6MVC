using System.Linq.Expressions;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace DataAccess.Repositories;

public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
{
    public void Insert(TEntity entity)
    {
        using var _context = new BlogDemoContext();
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        using var _context = new BlogDemoContext();
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        using var _context = new BlogDemoContext();
        _context.Update(entity);
        _context.SaveChanges();
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        using var _context = new BlogDemoContext();
        return filter==null
                   ? _context.Set<TEntity>().ToList()
                   : _context.Set<TEntity>().Where(filter).ToList();
    }


    public TEntity GetById(int id)
    {
        using var _context = new BlogDemoContext();
        return _context.Set<TEntity>().Find(id);
    }


}