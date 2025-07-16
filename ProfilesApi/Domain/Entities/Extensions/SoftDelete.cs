namespace Domain.Entities.Extensions;

public abstract class SoftDelete : BaseUserModel
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}