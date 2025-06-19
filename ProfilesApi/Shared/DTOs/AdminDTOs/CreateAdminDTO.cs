namespace Shared.DTOs.AdminDTOs;

public record CreateAdminDTOs(
    string? AdminFirstName,
    string? AdminMiddleName,
    string? AdminLastName,
    DateTime AdminDateBirth
);