namespace Shared.DTOs.PatientDTOs;

public record CreatePatientDTO(
    string? PatientFirstName,
    string? PatientMiddleName,
    string? PatientLastName,
    DateTime PatientDateBirth
);