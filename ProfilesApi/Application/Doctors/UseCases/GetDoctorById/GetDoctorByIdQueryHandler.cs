using Application.Doctors.Models;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Doctors.UseCases.GetDoctorById;

public sealed class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDTO>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IValidator<GetDoctorByIdQuery> _validator;

    public GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository, IValidator<GetDoctorByIdQuery> validator)
    {
        _doctorRepository = doctorRepository;
        _validator = validator;
    }

    public async Task<DoctorDTO> Handle(GetDoctorByIdQuery request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Incorrect Id");
        }

        var doctor = await _doctorRepository.GetByIdAsync(request.Id, token);

        if (doctor is null)
        {
            throw new NotFoundException($"Doctor with id: {request.Id} doesn't exist");
        }

        return new DoctorDTO(
                    doctor.Id,
                    doctor.FirstName,
                    doctor.LastName,
                    doctor.Email,
                    doctor.DateBirth,
                    doctor.CareerStartYear,
                    doctor.SpecializationId,
                    doctor.OfficeId
                );
    }

}