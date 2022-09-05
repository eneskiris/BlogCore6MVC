namespace DataAccess.Abstract;

public interface IGenericDal<TEntity> where TEntity:class
{
    void Insert(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GettAll();
    TEntity GetById(int id);
}