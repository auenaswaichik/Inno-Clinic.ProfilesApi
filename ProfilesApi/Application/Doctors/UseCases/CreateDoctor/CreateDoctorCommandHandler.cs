using Application.Doctors.Models;
using Domain.Entities;
using Domain.Interfaces.IRepositories;
using MediatR;

namespace Application.Doctors.UseCases.CreateDoctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDTO>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DoctorDTO> Handle(CreateDoctorCommand request, CancellationToken token)
    {
        var doctor = new Doctor()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateBirth = request.DateBirth,
            CareerStartYear = request.CareerStartYear
        };

        var createdDoctor = _doctorRepository.Insert(doctor);
        await _unitOfWork.SaveAsync();

        return new DoctorDTO(
                    createdDoctor.FirstName,
                    createdDoctor.LastName,
                    createdDoctor.DateBirth,
                    createdDoctor.CareerStartYear,
                    createdDoctor.ProfileId,
                    createdDoctor.SpecializationId,
                    createdDoctor.OfficeId
                );
    }
}