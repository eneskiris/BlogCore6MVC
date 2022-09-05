namespace Entities.Concrete;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }

    public List<Blog> Blogs { get; set; }
}