namespace Application.Patients.Models;

public record PatientDTO
{
    public Guid Id { get; init; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    
    public PatientDTO(Guid id, string? firstName, string? lastName, DateTime dateBirth)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateBirth = dateBirth;
    }
};