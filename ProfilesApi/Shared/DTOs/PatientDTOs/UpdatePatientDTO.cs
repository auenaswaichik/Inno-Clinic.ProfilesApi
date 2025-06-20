namespace Shared.DTOs.PatientDTOs;

public record UpdatePatientDTO(
    string? PatientFirstName,
    string? PatientMiddleName,
    string? PatientLastName,
    DateTime PatientDateBirth
);