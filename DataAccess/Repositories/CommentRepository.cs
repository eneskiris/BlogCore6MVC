using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Repositories;

public class CommentRepository : IGenericDal<Comment>
{
    public void Insert(Comment entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Comment entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Comment entity)
    {
        throw new NotImplementedException();
    }

    public List<Comment> GettAll()
    {
        throw new NotImplementedException();
    }

    public Comment GetById(int id)
    {
        throw new NotImplementedException();
    }
}