using System.Text;
using Application.Admins.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using Infrastructure.Messages.UserCreatedMessages;
using MassTransit;
using MediatR;

namespace Application.Admins.UseCases.CreateAdmin;

public sealed class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, AdminDTO>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateAdminCommand> _validator;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateAdminCommandHandler(IAdminRepository adminRepository, IUnitOfWork unitOfWork, IValidator<CreateAdminCommand> validator, IPublishEndpoint publishEndpoint)
    {
        _adminRepository = adminRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _publishEndpoint = publishEndpoint;
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
            Email = request.Email,
            DateBirth = request.DateBirth
        };

        var createdAdmin = _adminRepository.Insert(admin);
        await _unitOfWork.SaveAsync(token);

        await _publishEndpoint.Publish(
            new UserCreatedMessage
            {
                Id = createdAdmin.Id,
                FirstName = createdAdmin.FirstName,
                Email = createdAdmin.Email,
                Role = Roles.Admin,
                CreatedAt = DateTime.UtcNow
            }
        );

        return new AdminDTO(
                    createdAdmin.FirstName,
                    createdAdmin.LastName,
                    createdAdmin.DateBirth,
                    createdAdmin.OfficeId
                );
    }
}