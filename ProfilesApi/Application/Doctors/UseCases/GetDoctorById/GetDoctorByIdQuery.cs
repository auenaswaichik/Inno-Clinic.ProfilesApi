using Application.Doctors.Models;
using MediatR;

namespace Application.Doctors.UseCases.GetDoctorById;

public class GetDoctorByIdQuery : IRequest<DoctorDTO>
{
    public Guid Id{ get; set; }
}