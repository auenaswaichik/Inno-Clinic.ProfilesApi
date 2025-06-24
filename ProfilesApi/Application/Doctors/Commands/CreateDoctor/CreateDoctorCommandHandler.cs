using Domain.Entities;
using Domain.Interfaces.IManagers;
using Domain.Interfaces.IRepositories;
using MediatR;

namespace Application.Doctors.Commands.CreateDoctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Doctor>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Doctor> Handle(CreateDoctorCommand request, CancellationToken token)
    {
        var doctor = new Doctor()
        {
            DoctorFirstName = request.DoctorFirstName,
            DoctorMiddleName = request.DoctorMiddleName,
            DoctorLastName = request.DoctorLastName,
            DoctorDateBirth = request.DoctorDateBirth,
            DoctorCareerStartYear = request.DoctorCareerStartYear
        };
        //_unitOfWork.BeginTransaction();
        var createdDoctor = _doctorRepository.Insert(doctor, token);
        await _unitOfWork.SaveAsync();
        return createdDoctor;
    }
}