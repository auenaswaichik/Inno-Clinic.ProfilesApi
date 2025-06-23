using MediatR;
using Infrastructure.Repositories;
using Domain.Interfaces.IManagers;
using Domain.Entities;

namespace Application.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<Doctor>>
{
    private readonly DoctorRepository _repository;
    public GetAllDoctorsQueryHandler(DoctorRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Doctor>> Handle(GetAllDoctorsQuery request, CancellationToken token)
    {
        return await _repository.GetAll(token);
    }
}