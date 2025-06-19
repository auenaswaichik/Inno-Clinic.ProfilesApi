namespace Shared.DTOs.DoctorDTOs;

public record CreateDoctorDTOs(
    string? DoctorFirstName,
    string? DoctorMiddleName,
    string? DoctorLastName,
    DateTime DoctorDateBirth,
    DateOnly DoctorCareerStartYear
);