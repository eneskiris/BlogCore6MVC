namespace Entities.Concrete;

public class Comment
{
    public int CommentId { get; set; }
    public string UserName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    public int BlogScore { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}