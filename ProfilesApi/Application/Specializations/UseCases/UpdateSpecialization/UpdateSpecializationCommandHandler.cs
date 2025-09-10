using System.Text;
using Application.Specializations.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Specializations.UseCases.UpdateSpecialization;

public sealed class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand, SpecializationDTO>
{
    private readonly ISpecializationRepository _specializationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateSpecializationCommand> _validator;

    public UpdateSpecializationCommandHandler(ISpecializationRepository specializationRepository, IUnitOfWork unitOfWork, IValidator<UpdateSpecializationCommand> validator)
    {
        _specializationRepository = specializationRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<SpecializationDTO> Handle(UpdateSpecializationCommand request, CancellationToken token)
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

        var specialization = new Specialization()
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description
        };

        var updatedSpecialization = _specializationRepository.Update(specialization);
        await _unitOfWork.SaveAsync(token);

        updatedSpecialization = await _specializationRepository.GetByIdAsync(updatedSpecialization.Id, token);

        return new SpecializationDTO(
                    updatedSpecialization.Id,
                    updatedSpecialization.Name,
                    updatedSpecialization.Description,
                    updatedSpecialization.Doctors.Select(d => d.FirstName).ToList()
                );
    }
}