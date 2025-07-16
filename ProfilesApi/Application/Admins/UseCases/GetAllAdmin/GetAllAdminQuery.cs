using Application.Admins.Models;
using Domain.Entities.Extensions;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Admins.UseCases.GetAllAdmins;

public class GetAllAdminsQuery : IRequest<PagedList<AdminDTO>>
{
    public AdminParameters AdminParameters{ get; set; }
}