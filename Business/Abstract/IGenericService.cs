namespace Business.Abstract;

public interface IGenericService<TEntity>
{
    void Add(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GetList();
    TEntity GetById(int id);
}