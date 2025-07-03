namespace Domain.Entities;

public sealed class Patient : BaseUserModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public Guid ProfileId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}