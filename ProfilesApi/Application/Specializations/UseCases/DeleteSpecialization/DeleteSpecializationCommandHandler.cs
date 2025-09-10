using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Specializations.UseCases.DeleteSpecialization;

public sealed class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand>
{
    private readonly ISpecializationRepository _specializationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeleteSpecializationCommand> _validator;

    public DeleteSpecializationCommandHandler(ISpecializationRepository specializationRepository, IUnitOfWork unitOfWork, IValidator<DeleteSpecializationCommand> validator)
    {
        _specializationRepository = specializationRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(DeleteSpecializationCommand request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Incorrect Id");
        }

        var specialization = await _specializationRepository.GetByIdAsync(request.Id, token);

        if (specialization is null)
        {
            throw new NotFoundException($"Specialization with id: {request.Id} doesn't exist");
        }

        _specializationRepository.Delete(specialization);
        await _unitOfWork.SaveAsync(token);
    }
}