namespace Shared.DTOs.AdminDTOs;

public record CreateAdminDTO(
    string? AdminFirstName,
    string? AdminMiddleName,
    string? AdminLastName,
    DateTime AdminDateBirth
);