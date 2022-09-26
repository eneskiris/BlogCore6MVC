

using System.ComponentModel.DataAnnotations;

namespace MvcUI.Models;

public class UserSignInViewModel
{
    [Required(ErrorMessage = "Username is required")]
    public string username { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string password { get; set; }
}