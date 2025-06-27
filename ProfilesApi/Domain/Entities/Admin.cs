namespace Domain.Entities;

public sealed class Admin : BaseUserModel
{

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public Guid ProfileId { get; set; }
    public Guid OfficeId { get; set; }

}