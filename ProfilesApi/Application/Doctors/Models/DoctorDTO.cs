namespace Application.Doctors.Models;

public record DoctorDTO
{
    public Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public DateTime DateBirth { get; init; }
    public DateTime CareerStartYear { get; init; }
    public string Specialization{ get; init; }
    public Guid OfficeId { get; init; }
    
    public DoctorDTO(Guid id, string? firstName, string? lastName, string? email, DateTime dateBirth, DateTime careerStartYear, string specialization, Guid officeId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateBirth = dateBirth;
        CareerStartYear = careerStartYear;
        Specialization = specialization;
        OfficeId = officeId;
    }
};