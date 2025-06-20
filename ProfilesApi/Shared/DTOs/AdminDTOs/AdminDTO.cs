namespace Shared.DTOs.AdminDTOs;

public record AdminDTO(
    string? AdminFirstName,
    string? AdminMiddleName,
    string? AdminLastName,
    DateTime AdminDateBirth
);