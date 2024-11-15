using System.ComponentModel.DataAnnotations;
using Maktab.Sample.Blog.Presentation.Resources;

namespace Maktab.Sample.Blog.Presentation.Models.Accounting;

public class RegisterViewModel
{
    [Display(Name = "FirstNameProp",ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [MinLength(3, ErrorMessageResourceName = "MinLengthStringValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
    public string FirstName { get; set; }
    
    [Display(Name = "LastNameProp",ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [StringLength(30, ErrorMessageResourceName = "StringLengthValidationMessage", ErrorMessageResourceType = typeof(PresentationResources), MinimumLength = 3)]
    public string LastName { get; set; }
    
    [Display(Name = "EmailProp",ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [EmailAddress(ErrorMessageResourceName = "InvalidEmailAddress", ErrorMessageResourceType = typeof(PresentationResources))]
    public string Email { get; set; }
    
    [Display(Name = "UsernameProp",ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [MinLength(3, ErrorMessageResourceName = "MinLengthStringValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
    public string UserName { get; set; }
    
    [Display(Name = "PasswordProp" ,ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
        ErrorMessageResourceType = typeof(PresentationResources),
        ErrorMessageResourceName = "InvalidPassword")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Display(Name = "RePasswordProp" ,ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [Compare("Password", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "InvalidRePassword")]
    [DataType(DataType.Password)]
    public string RePassword { get; set; }
    
    [Display(Name = "PhoneNumberProp" ,ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
    [RegularExpression(@"^(0|\+98)\d{10}", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
    public string PhoneNumber { get; set; }
}