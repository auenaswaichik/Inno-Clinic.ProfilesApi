using Application.Admins.Models;
using Domain.Entities.Extensions;
using MediatR;

namespace Application.Admins.UseCases.GetAllAdmins;

public class GetAllAdminsQuery : IRequest<PagedList<AdminDTO>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}