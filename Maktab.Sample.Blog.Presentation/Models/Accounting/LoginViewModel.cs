using System.ComponentModel.DataAnnotations;
using Maktab.Sample.Blog.Presentation.Resources;

namespace Maktab.Sample.Blog.Presentation.Models.Accounting;

public class LoginViewModel
{
    [Display(Name = "UsernameProp", ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
    public string Username { get; set; }
    
    [Display(Name = "PasswordProp", ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}