using MediatR;
using Domain.Interfaces.IRepositories;
using Application.Admins.Models;
using Domain.Entities.Extensions;

namespace Application.Admins.UseCases.GetAllAdmins;

public sealed class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, PagedList<AdminDTO>>
{
    private readonly IAdminRepository _adminRepository;

    public GetAllAdminsQueryHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<PagedList<AdminDTO>> Handle(GetAllAdminsQuery request, CancellationToken token)
    {
        var adminsList = await _adminRepository.GetDoctorsAsync(request.AdminParameters, token);

        var adminsDTOsList = adminsList.Items
            .Select(m =>
                new AdminDTO(
                    m.FirstName,
                    m.LastName,
                    m.DateBirth,
                    m.OfficeId
                ))
            .ToList();

        return new PagedList<AdminDTO>(adminsDTOsList, adminsList.TotalCount, adminsList.PageIndex, adminsList.PageSize);
    }
}