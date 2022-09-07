using Entities.Concrete;

namespace Business.Abstract;

public interface ICommentService
{
    void CommentAdd(Comment comment);
    // void CommentDelete(Comment comment);
    // void CommentUpdate(Comment comment);
    List<Comment> GetList();
    List<Comment> GetListByBlogId(int id);
    // Comment GetById(int id);
}