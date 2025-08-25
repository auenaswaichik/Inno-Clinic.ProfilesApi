namespace Application.Doctors.Models;

public record DoctorDTO
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime DateBirth { get; init; }
    public DateTime CareerStartYear { get; init; }
    public Guid SpecializationId { get; init; }
    public Guid OfficeId { get; init; }
    
    public DoctorDTO(string? firstName, string? lastName, DateTime dateBirth, DateTime careerStartYear, Guid specializationId, Guid officeId)
    {
        FirstName = firstName;
        LastName = lastName;
        DateBirth = dateBirth;
        CareerStartYear = careerStartYear;
        SpecializationId = specializationId;
        OfficeId = officeId;
    }
};