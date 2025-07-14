using Application.Patients.Models;
using Domain.Entities.Extensions;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Patients.UseCases.GetAllPatients;

public class GetAllPatientsQuery : IRequest<PagedList<PatientDTO>>
{
    public PatientParameters PatientParameters;
}
