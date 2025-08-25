namespace Application.Patients.Models;

public record PatientDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    
    public PatientDTO(string? firstName, string? lastName, DateTime dateBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateBirth = dateBirth;
    }
};