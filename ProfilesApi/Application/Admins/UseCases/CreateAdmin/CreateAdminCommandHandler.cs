using System.Text;
using Application.Admins.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Admins.UseCases.CreateAdmin;

public sealed class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, AdminDTO>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateAdminCommand> _validator;

    public CreateAdminCommandHandler(IAdminRepository adminRepository, IUnitOfWork unitOfWork, IValidator<CreateAdminCommand> validator)
    {
        _adminRepository = adminRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<AdminDTO> Handle(CreateAdminCommand request, CancellationToken token)
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

        var admin = new Admin()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateBirth = request.DateBirth
        };

        var createdAdmin = _adminRepository.Insert(admin);
        await _unitOfWork.SaveAsync(token);

        return new AdminDTO(
                    createdAdmin.FirstName,
                    createdAdmin.LastName,
                    createdAdmin.DateBirth,
                    createdAdmin.ProfileId,
                    createdAdmin.OfficeId
                );
    }
}