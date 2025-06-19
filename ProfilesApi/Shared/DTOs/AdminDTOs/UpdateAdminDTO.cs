namespace Shared.DTOs.AdminDTOs;

public record UpdateAdminDTOs(
    string? AdminFirstName,
    string? AdminMiddleName,
    string? AdminLastName,
    DateTime AdminDateBirth
);