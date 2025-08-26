using Application.Admins.Models;
using MediatR;

namespace Application.Admins.UseCases.CreateAdmin;

public class CreateAdminCommand : IRequest<AdminDTO>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime DateBirth { get; set; }
}