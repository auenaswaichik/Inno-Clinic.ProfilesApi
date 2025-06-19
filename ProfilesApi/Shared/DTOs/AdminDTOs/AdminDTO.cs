namespace Shared.DTOs.AdminDTOs;

public record AdminDTOs(
    string? AdminFirstName,
    string? AdminMiddleName,
    string? AdminLastName,
    DateTime AdminDateBirth
);