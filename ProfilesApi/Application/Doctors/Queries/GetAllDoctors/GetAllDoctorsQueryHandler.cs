using MediatR;
using Infrastructure.Repositories;
using Domain.Interfaces.IManagers;
using Domain.Entities;
using Domain.Interfaces.IRepositories;

namespace Application.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<Doctor>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetAllDoctorsQueryHandler(IDoctorRepository repository)
    {
        _doctorRepository = repository;
    }

    public async Task<List<Doctor>> Handle(GetAllDoctorsQuery request, CancellationToken token)
    {
        return await _doctorRepository.GetAll(token);
    }
}