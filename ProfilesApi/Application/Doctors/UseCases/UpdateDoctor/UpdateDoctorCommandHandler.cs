using Application.Doctors.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using MediatR;

namespace Application.Doctors.UseCases.UpdateDoctor;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, DoctorDTO>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DoctorDTO> Handle(UpdateDoctorCommand request, CancellationToken token)
    {
        var validations = new UpdateDoctorCommandValidator();
        var valRes = validations.Validate(request);

        if (!valRes.IsValid)
        {
            throw new BadRequestException("Bad request for update doctor command");
        }

        var doctor = new Doctor()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateBirth = request.DateBirth,
            CareerStartYear = request.CareerStartYear,
            ProfileId = request.ProfileId,
            SpecializationId = request.SpecializationId,
            OfficeId = request.OfficeId
        };

        var updatedDoctor = _doctorRepository.Update(doctor);
        await _unitOfWork.SaveAsync();

        return new DoctorDTO(
                    updatedDoctor.FirstName,
                    updatedDoctor.LastName,
                    updatedDoctor.DateBirth,
                    updatedDoctor.CareerStartYear,
                    updatedDoctor.ProfileId,
                    updatedDoctor.SpecializationId,
                    updatedDoctor.OfficeId
                );
    }
}