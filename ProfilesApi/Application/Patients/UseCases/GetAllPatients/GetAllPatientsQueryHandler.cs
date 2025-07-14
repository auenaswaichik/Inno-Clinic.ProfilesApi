using MediatR;
using Domain.Interfaces.IRepositories;
using Application.Patients.Models;
using Domain.Entities.Extensions;

namespace Application.Patients.UseCases.GetAllPatients;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, PagedList<PatientDTO>>
{
    private readonly IPatientRepository _patientRepository;

    public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PagedList<PatientDTO>> Handle(GetAllPatientsQuery request, CancellationToken token)
    {
        var patientsList = await _patientRepository.GetDoctorsAsync(request.PatientParameters, token);
        
        var patientsDTOsList = patientsList.Items
            .Select(m =>
                new PatientDTO(
                    m.FirstName,
                    m.LastName,
                    m.DateBirth,
                    m.ProfileId
                ))
            .ToList();
            
        return new PagedList<PatientDTO>(patientsDTOsList, patientsList.TotalCount, patientsList.PageIndex, patientsList.PageSize);
    }
}