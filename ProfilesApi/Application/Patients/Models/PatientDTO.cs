namespace Application.Patients.Models;

public record PatientDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public Guid ProfileId { get; set; }
    
    public PatientDTO(string? firstName, string? lastName, DateTime dateBirth, Guid profileId)
    {
        FirstName = firstName;
        LastName = lastName;
        DateBirth = dateBirth;
        ProfileId = profileId;
    }
};