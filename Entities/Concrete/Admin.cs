using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Admin
{
    [Key]
    public int AdminId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    public string Role { get; set; }
    
    
}