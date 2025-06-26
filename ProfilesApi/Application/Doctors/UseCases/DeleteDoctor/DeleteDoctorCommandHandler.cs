using Application.Doctors.Models;
using Application.Doctors.UseCases.GetDoctorById;
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
        var doctor = await _doctorRepository.GetByIdAsync(request.Id, token);
        _doctorRepository.Delete(doctor);
        await _unitOfWork.SaveAsync();
    }
}