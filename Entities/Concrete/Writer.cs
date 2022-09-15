namespace Entities.Concrete;

public class Writer
{
    public int WriterId { get; set; }
    public string FullName { get; set; }
    public string About { get; set; }
    public string? Image { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }
    public List<Blog> Blogs { get; set; }
}