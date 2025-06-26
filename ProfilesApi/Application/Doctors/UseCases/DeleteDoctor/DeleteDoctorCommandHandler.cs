using Application.Doctors.Models;
using Domain.Entities;
using Domain.Interfaces.IRepositories;
using MediatR;

namespace Application.Doctors.UseCases.DeleteDoctor;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{

    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteDoctorCommand request, CancellationToken token)
    {
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
        _doctorRepository.Delete(doctor);
        await _unitOfWork.SaveAsync();
    }
}