using System.ComponentModel.DataAnnotations;
using Maktab.Sample.Blog.Presentation.Resources;

namespace Maktab.Sample.Blog.Presentation.Pages.Models;

public class AddPostModel
{
    [Display(Name = "PostTitleProp", ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
    [MinLength(5, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
    [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
    public string PostTitle { get; set; }
    
    [Display(Name = "PostTextProp", ResourceType = typeof(PresentationResources))]
    [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
    [MinLength(20, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MinLengthStringValidationMessage")]
    [DataType(DataType.MultilineText)]
    public string PostText { get; set; }
}