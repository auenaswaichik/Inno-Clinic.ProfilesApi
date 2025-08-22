using System.Text;
using Application.Doctors.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using Infrastructure.Messages.UserCreatedMessages;
using MassTransit;
using MediatR;

namespace Application.Doctors.UseCases.CreateDoctor;

public sealed class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDTO>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateDoctorCommand> _validator;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork, IValidator<CreateDoctorCommand> validator, IPublishEndpoint publishEndpoint)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<DoctorDTO> Handle(CreateDoctorCommand request, CancellationToken token)
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
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateBirth = request.DateBirth,
            CareerStartYear = request.CareerStartYear
        };

        var createdDoctor = _doctorRepository.Insert(doctor);
        await _unitOfWork.SaveAsync(token);

        await _publishEndpoint.Publish(
            new UserCreatedMessage(){
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = "a",
                Role = "Doctor",
                CreatedAt = DateTime.UtcNow
            }
        );

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