using System.Text;
using Application.Admins.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Admins.UseCases.UpdateAdmin;

public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, AdminDTO>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateAdminCommand> _validator;

    public UpdateAdminCommandHandler(IAdminRepository adminRepository, IUnitOfWork unitOfWork, IValidator<UpdateAdminCommand> validator)
    {
        _adminRepository = adminRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<AdminDTO> Handle(UpdateAdminCommand request, CancellationToken token)
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
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateBirth = request.DateBirth,
            ProfileId = request.ProfileId,
            OfficeId = request.OfficeId
        };

        var updatedAdmin = _adminRepository.Update(admin);
        await _unitOfWork.SaveAsync(token);

        return new AdminDTO(
                    updatedAdmin.FirstName,
                    updatedAdmin.LastName,
                    updatedAdmin.DateBirth,
                    updatedAdmin.ProfileId,
                    updatedAdmin.OfficeId
                );
    }
}