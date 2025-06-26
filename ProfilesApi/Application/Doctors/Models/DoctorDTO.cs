namespace Application.Doctors.Models;

public record DoctorDTO
(

    string? FirstName,
    string? LastName,
    DateTime DateBirth,
    DateTime CareerStartYear, 
    Guid ProfileId,
    Guid SpecializationId, 
    Guid OfficeId

);