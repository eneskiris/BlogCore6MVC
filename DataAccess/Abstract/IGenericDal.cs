using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface IGenericDal<TEntity> where TEntity:class
{
    void Insert(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GettAll(Expression<Func<TEntity, bool>> filter = null);
    TEntity GetById(int id);
}