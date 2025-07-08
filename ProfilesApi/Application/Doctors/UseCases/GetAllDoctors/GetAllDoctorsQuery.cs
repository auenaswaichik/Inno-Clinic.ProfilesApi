using Application.Doctors.Models;
using Domain.Entities.Extensions;
using MediatR;

namespace Application.Doctors.UseCases.GetAllDoctors;

public class GetAllDoctorsQuery : IRequest<PagedList<DoctorDTO>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}