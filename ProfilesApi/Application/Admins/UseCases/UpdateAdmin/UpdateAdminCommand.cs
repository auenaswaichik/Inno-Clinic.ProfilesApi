using Application.Admins.Models;
using MediatR;

namespace Application.Admins.UseCases.UpdateAdmin;

public class UpdateAdminCommand : IRequest<AdminDTO>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public Guid OfficeId { get; set; }

}