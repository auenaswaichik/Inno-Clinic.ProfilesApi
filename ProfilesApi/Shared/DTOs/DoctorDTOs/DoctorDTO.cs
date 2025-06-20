namespace Shared.DTOs.DoctorDTOs;

public record DoctorDTO(
    string? DoctorFirstName,
    string? DoctorMiddleName,
    string? DoctorLastName,
    DateTime DoctorDateBirth,
    DateOnly DoctorCareerStartYear
);