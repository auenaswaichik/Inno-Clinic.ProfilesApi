using System.Text;
using Application.Specializations.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MassTransit;
using MediatR;

namespace Application.Specializations.UseCases.CreateSpecialization;

public sealed class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, SpecializationDTO>
{
    private readonly ISpecializationRepository _specializationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateSpecializationCommand> _validator;

    public CreateSpecializationCommandHandler(ISpecializationRepository specializationRepository, IUnitOfWork unitOfWork, IValidator<CreateSpecializationCommand> validator)
    {
        _specializationRepository = specializationRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<SpecializationDTO> Handle(CreateSpecializationCommand request, CancellationToken token)
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

        var Specialization = new Specialization()
        {
            Name = request.Name,
            Description = request.Description
        };

        var createdSpecialization = _specializationRepository.Insert(Specialization);
        await _unitOfWork.SaveAsync(token);

        createdSpecialization = await _specializationRepository.GetByIdAsync(createdSpecialization.Id, token); 

        return new SpecializationDTO(
                    createdSpecialization.Id,
                    createdSpecialization.Name,
                    createdSpecialization.Description,
                    createdSpecialization.Doctors.Select(d => d.FirstName).ToList()
                );
    }
}