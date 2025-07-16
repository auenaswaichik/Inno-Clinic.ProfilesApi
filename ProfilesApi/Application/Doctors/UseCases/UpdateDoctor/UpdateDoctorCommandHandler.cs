using System.Text;
using Application.Doctors.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Doctors.UseCases.UpdateDoctor;

public sealed class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, DoctorDTO>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateDoctorCommand> _validator;

    public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork, IValidator<UpdateDoctorCommand> validator)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<DoctorDTO> Handle(UpdateDoctorCommand request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var stringBuilder = new StringBuilder();

            foreach (var error in validationResult.Errors)
            {
                stringBuilder.AppendLine(error.ErrorMessage);
            }

            throw new BadRequestException(stringBuilder.ToString());
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
        await _unitOfWork.SaveAsync(token);

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