using Application.Doctors.Models;
using Domain.Interfaces.IRepositories;
using MediatR;

namespace Application.Doctors.UseCases.GetDoctorById;

public class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDTO>
{
    private readonly IDoctorRepository doctorRepository;

    public GetDoctorByIdHandler(IDoctorRepository repository)
    {
        doctorRepository = repository;
    }

    public async Task<DoctorDTO> Handle(GetDoctorByIdQuery request, CancellationToken token)
    {
        var doctor = await doctorRepository.GetByIdAsync(request.Id, token);
        
        return new DoctorDTO(
                    doctor.FirstName,
                    doctor.LastName,
                    doctor.DateBirth,
                    doctor.CareerStartYear,
                    doctor.ProfileId,
                    doctor.SpecializationId,
                    doctor.OfficeId
                );
    }

}