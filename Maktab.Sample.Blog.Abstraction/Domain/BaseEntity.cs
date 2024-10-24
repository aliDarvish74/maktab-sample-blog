namespace Maktab.Sample.Blog.Abstraction.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }

    protected abstract void Validate();

    public void SoftDeleteEntity()
    {
        IsDeleted = true;
        DeletedAt = DateTime.Now;
    }
}