using Domain.Entities.Extensions;

namespace Domain.Entities;

public sealed class Patient : SoftDelete
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public Guid ProfileId { get; set; }
}