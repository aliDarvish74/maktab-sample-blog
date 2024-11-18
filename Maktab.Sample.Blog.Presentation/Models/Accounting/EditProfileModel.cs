using Maktab.Sample.Blog.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace Maktab.Sample.Blog.Presentation.Models.Accounting
{
    public class EditProfileModel
    {
        [Display(Name = "FirstNameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [MinLength(3, ErrorMessageResourceName = "MinLengthStringValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [MaxLength(30, ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "MaxLengthStringValidationMessage")]
        public string FirstName { get; set; }

        [Display(Name = "LastNameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [StringLength(30, ErrorMessageResourceName = "StringLengthValidationMessage", ErrorMessageResourceType = typeof(PresentationResources), MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "EmailProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmailAddress", ErrorMessageResourceType = typeof(PresentationResources))]
        public string Email { get; set; }
        [Display(Name = "PhoneNumberProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceName = "RequiredValidationMessage", ErrorMessageResourceType = typeof(PresentationResources))]
        [RegularExpression(@"^(0|\+98)\d{10}", ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "InvalidPhoneNumber")]
        public string PhoneNumber { get; set; }

    }
}
