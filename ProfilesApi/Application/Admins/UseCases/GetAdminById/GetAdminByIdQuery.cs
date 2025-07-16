using Application.Admins.Models;
using MediatR;

namespace Application.Admins.UseCases.GetAdminById;

public class GetAdminByIdQuery : IRequest<AdminDTO>
{
    public Guid Id{ get; set; }
}