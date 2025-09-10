using MediatR;
using Domain.Interfaces.IRepositories;
using Application.Doctors.Models;
using Domain.Entities.Extensions;

namespace Application.Doctors.UseCases.GetAllDoctors;

public sealed class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, PagedList<DoctorDTO>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<PagedList<DoctorDTO>> Handle(GetAllDoctorsQuery request, CancellationToken token)
    {
        var doctorsList = await _doctorRepository.GetDoctorsAsync(request.DoctorParameters, token);

        var doctorsDTOsList = doctorsList.Items
            .Select(m =>
                new DoctorDTO(
                    m.Id,
                    m.FirstName,
                    m.LastName,
                    m.Email,
                    m.DateBirth,
                    m.CareerStartYear,
                    m.Specialization?.Name ?? string.Empty,
                    m.OfficeId
                ));
        return new PagedList<DoctorDTO>(doctorsDTOsList, doctorsList.TotalCount, doctorsList.PageIndex, doctorsList.PageSize);
    }
}