using MediatR;
using Domain.Interfaces.IRepositories;
using Application.Doctors.Models;

namespace Application.Doctors.UseCases.GetAllDoctors;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<DoctorDTO>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<DoctorDTO>> Handle(GetAllDoctorsQuery request, CancellationToken token)
    {
        var doctorsList = await _doctorRepository.GetAllAsync(token);
        
        return doctorsList
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
    }
}