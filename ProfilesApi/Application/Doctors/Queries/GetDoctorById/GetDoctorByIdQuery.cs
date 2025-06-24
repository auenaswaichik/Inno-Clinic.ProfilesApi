using Domain.Entities;
using MediatR;

namespace Application.Doctors.Queries.GetDoctorById;

public class GetDoctorByIdQuery : IRequest<Doctor>
{

    public Guid Id;

}