using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CommentManager : ICommentService
{
    private ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }

    public void CommentAdd(Comment comment)
    {
        _commentDal.Insert(comment);
    }

    public List<Comment> GetList()
    {
        return _commentDal.GetAll();
    }

    public List<Comment> GetListByBlogId(int id)
    {
        return _commentDal.GetAll(x => x.BlogId == id);
    }

    public List<Comment> GetListWithBlog()
    {
        return _commentDal.GetListWithBlog();
    }
}