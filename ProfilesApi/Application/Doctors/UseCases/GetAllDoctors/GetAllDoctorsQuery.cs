using Application.Doctors.Models;
using Domain.Entities.Extensions;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Doctors.UseCases.GetAllDoctors;

public class GetAllDoctorsQuery : IRequest<PagedList<DoctorDTO>>
{
    public DoctorParameters DoctorParameters;
}