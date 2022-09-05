namespace Entities.Concrete;

public class Blog
{
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ThumbnailImage { get; set; }
    public string Image { get; set; }
    public DateTime CreateDate { get; set; }
    public bool Status { get; set; }
}