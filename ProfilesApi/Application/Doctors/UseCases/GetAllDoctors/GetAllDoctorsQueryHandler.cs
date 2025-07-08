using MediatR;
using Domain.Interfaces.IRepositories;
using Application.Doctors.Models;
using Domain.Entities.Extensions;

namespace Application.Doctors.UseCases.GetAllDoctors;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, PagedList<DoctorDTO>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<PagedList<DoctorDTO>> Handle(GetAllDoctorsQuery request, CancellationToken token)
    {
        var doctorsList = await _doctorRepository.GetAllAsync(token);

        var doctorsDTOsList = doctorsList
            .Select(m =>
                new DoctorDTO(
                    m.FirstName,
                    m.LastName,
                    m.DateBirth,
                    m.CareerStartYear,
                    m.ProfileId,
                    m.SpecializationId,
                    m.OfficeId
                ))
            .ToList();

        var doctorsPage = PagedList<DoctorDTO>.Create(doctorsDTOsList, request.PageIndex, request.PageSize);

        return doctorsPage;
    }
}