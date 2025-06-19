namespace Shared.DTOs.PatientDTOs;

public record PatientDTOs(
    string? PatientFirstName,
    string? PatientMiddleName,
    string? PatientLastName,
    DateTime PatientDateBirth
);