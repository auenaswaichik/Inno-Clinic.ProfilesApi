using MediatR;
using Domain.Interfaces.IRepositories;
using Application.Admins.Models;
using Domain.Entities.Extensions;

namespace Application.Admins.UseCases.GetAllAdmins;

public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, PagedList<AdminDTO>>
{
    private readonly IAdminRepository _adminRepository;

    public GetAllAdminsQueryHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<PagedList<AdminDTO>> Handle(GetAllAdminsQuery request, CancellationToken token)
    {
        var adminsList = await _adminRepository.GetAllAsync(token);

        var adminsDTOsList = adminsList
            .Select(m =>
                new AdminDTO(
                    m.FirstName,
                    m.LastName,
                    m.DateBirth,
                    m.ProfileId,
                    m.OfficeId
                ))
            .ToList();

        var adminsPage = PagedList<AdminDTO>.Create(adminsDTOsList, request.PageIndex, request.PageSize);

        return adminsPage;
    }
}