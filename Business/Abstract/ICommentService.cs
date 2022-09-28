using Entities.Concrete;

namespace Business.Abstract;

public interface ICommentService
{
    void CommentAdd(Comment comment);
    List<Comment> GetList();
    List<Comment> GetListByBlogId(int id);
    List<Comment> GetListWithBlog();
}