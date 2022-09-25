using System.ComponentModel.DataAnnotations;

namespace MvcUI.Models;

public class UserSignUpViewModel
{
    [Display(Name = "Full Name")]
    [Required (ErrorMessage = "Please enter your full name")]
    public string FullName { get; set; }
    
    [Display(Name = "Password")]
    [Required (ErrorMessage = "Please enter your password")]
    public string Password { get; set; }
    
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }
    
    [Display(Name = "Email")]
    [Required (ErrorMessage = "Please enter your email")]
    public string Email { get; set; }
    
    [Display(Name = "Username")]
    [Required (ErrorMessage = "Please enter your username")]
    public string UserName { get; set; }
}