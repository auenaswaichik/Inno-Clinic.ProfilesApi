namespace Shared.DTOs.PatientDTOs;

public record CreatePatientDTOs(
    string? PatientFirstName,
    string? PatientMiddleName,
    string? PatientLastName,
    DateTime PatientDateBirth
);