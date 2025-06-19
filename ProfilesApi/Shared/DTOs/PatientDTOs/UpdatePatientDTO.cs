namespace Shared.DTOs.PatientDTOs;

public record UpdatePatientDTOs(
    string? PatientFirstName,
    string? PatientMiddleName,
    string? PatientLastName,
    DateTime PatientDateBirth
);