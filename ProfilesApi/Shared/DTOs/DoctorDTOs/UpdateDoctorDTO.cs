namespace Shared.DTOs.DoctorDTOs;

public record UpdateDoctorDTOs(
    string? DoctorFirstName,
    string? DoctorMiddleName,
    string? DoctorLastName,
    DateTime DoctorDateBirth,
    DateOnly DoctorCareerStartYear
);