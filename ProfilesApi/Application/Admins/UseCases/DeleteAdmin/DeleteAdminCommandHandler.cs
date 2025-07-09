using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Admins.UseCases.DeleteAdmin;

public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeleteAdminCommand> _validator;

    public DeleteAdminCommandHandler(IAdminRepository adminRepository, IUnitOfWork unitOfWork, IValidator<DeleteAdminCommand> validator)
    {
        _adminRepository = adminRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(DeleteAdminCommand request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Incorrect Id");
        }

        var admin = await _adminRepository.GetByIdAsync(request.Id, token);

        if (admin is null)
        {
            throw new NotFoundException("There is no such Admin to delete");
        }

        _adminRepository.Delete(admin);
        await _unitOfWork.SaveAsync(token);
    }
}