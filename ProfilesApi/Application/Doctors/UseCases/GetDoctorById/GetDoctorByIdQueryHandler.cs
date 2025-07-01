using Application.Doctors.Models;
using Domain.Exceptions;
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
        var validations = new GetDoctorByIdQueryValidator();
        var valRes = validations.Validate(request);

        if (!valRes.IsValid)
        {
            throw new BadRequestException("Incorrect Id");
        }

        var doctor = await doctorRepository.GetByIdAsync(request.Id, token);

        if (doctor is null)
        {
            throw new NotFoundException("There is no such doctor to find");
        }

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