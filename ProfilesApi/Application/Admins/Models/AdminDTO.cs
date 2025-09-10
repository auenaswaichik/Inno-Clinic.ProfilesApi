namespace Application.Admins.Models;

public record AdminDTO
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime DateBirth { get; init; }
    public Guid OfficeId { get; init; }
    
    public AdminDTO(string? firstName, string? lastName, DateTime dateBirth, Guid officeId)
    {
        FirstName = firstName;
        LastName = lastName;
        DateBirth = dateBirth;
        OfficeId = officeId;
    }
};