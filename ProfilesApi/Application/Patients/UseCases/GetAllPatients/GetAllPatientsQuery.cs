using Application.Patients.Models;
using Domain.Entities.Extensions;
using MediatR;

namespace Application.Patients.UseCases.GetAllPatients;

public class GetAllPatientsQuery : IRequest<PagedList<PatientDTO>>
{
    public int PageIndex { get; set; }
    public int PageSize{ get; set; }
}
