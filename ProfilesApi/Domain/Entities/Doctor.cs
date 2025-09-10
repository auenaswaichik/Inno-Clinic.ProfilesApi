namespace Domain.Entities;

public sealed class Doctor : BaseUserModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public DateTime CareerStartYear { get; set; }
    public Guid SpecializationId { get; set; }
    public Specialization? Specialization { get; set; }
    public Guid OfficeId { get; set; }
}