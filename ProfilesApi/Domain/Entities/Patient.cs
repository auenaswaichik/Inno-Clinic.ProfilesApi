namespace Domain.Entities;

public sealed class Patient : BaseUserModel
{

    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public Guid ProfileId { get; set; }

}