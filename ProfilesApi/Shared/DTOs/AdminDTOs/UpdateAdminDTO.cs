namespace Shared.DTOs.AdminDTOs;

public record UpdateAdminDTO(
    string? AdminFirstName,
    string? AdminMiddleName,
    string? AdminLastName,
    DateTime AdminDateBirth
);