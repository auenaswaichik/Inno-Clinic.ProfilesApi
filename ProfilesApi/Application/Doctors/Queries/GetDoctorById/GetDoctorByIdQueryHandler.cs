using Domain.Entities;
using Domain.Interfaces.IRepositories;
using MediatR;

namespace Application.Doctors.Queries.GetDoctorById;

public class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
{

    private readonly IDoctorRepository doctorRepository;

    public GetDoctorByIdHandler(IDoctorRepository repository)
    {
        doctorRepository = repository;
    }

    public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken token)
    {
        return await doctorRepository.GetById(request.Id, token);
    }

}