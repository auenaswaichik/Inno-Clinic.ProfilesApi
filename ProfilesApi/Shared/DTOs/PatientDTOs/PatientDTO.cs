namespace Shared.DTOs.PatientDTOs;

public record PatientDTO(
    string? PatientFirstName,
    string? PatientMiddleName,
    string? PatientLastName,
    DateTime PatientDateBirth
);