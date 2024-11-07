using Microsoft.AspNetCore.Identity;

namespace Maktab.Sample.Blog.Domain.Roles;

public class Role : IdentityRole<Guid>
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
