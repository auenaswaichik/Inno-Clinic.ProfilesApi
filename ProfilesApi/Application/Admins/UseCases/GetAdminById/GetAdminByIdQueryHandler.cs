using Application.Admins.Models;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Admins.UseCases.GetAdminById;

public sealed class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, AdminDTO>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IValidator<GetAdminByIdQuery> _validator;

    public GetAdminByIdQueryHandler(IAdminRepository adminRepository, IValidator<GetAdminByIdQuery> validator)
    {
        _adminRepository = adminRepository;
        _validator = validator;
    }

    public async Task<AdminDTO> Handle(GetAdminByIdQuery request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Incorrect Id");
        }

        var admin = await _adminRepository.GetByIdAsync(request.Id, token);

        if (admin is null)
        {
            throw new NotFoundException($"Admin with id: {request.Id} doesn't exist");
        }

        return new AdminDTO(
                    admin.FirstName,
                    admin.LastName,
                    admin.DateBirth,
                    admin.ProfileId,
                    admin.OfficeId
                );
    }

}