namespace Shared.DTOs.DoctorDTOs;

public record UpdateDoctorDTO(
    string? DoctorFirstName,
    string? DoctorMiddleName,
    string? DoctorLastName,
    DateTime DoctorDateBirth,
    DateOnly DoctorCareerStartYear
);