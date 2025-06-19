namespace Shared.DTOs.DoctorDTOs;

public record DoctorDTOs(
    string? DoctorFirstName,
    string? DoctorMiddleName,
    string? DoctorLastName,
    DateTime DoctorDateBirth,
    DateOnly DoctorCareerStartYear
);