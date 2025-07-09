using MediatR;

namespace Application.Admins.UseCases.DeleteAdmin;

public class DeleteAdminCommand : IRequest
{
    public Guid Id { get; set; }
}