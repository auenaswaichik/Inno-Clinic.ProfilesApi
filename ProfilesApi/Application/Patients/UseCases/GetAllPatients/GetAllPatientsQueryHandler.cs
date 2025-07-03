using MediatR;
using Domain.Interfaces.IRepositories;
using Application.Patients.Models;

namespace Application.Patients.UseCases.GetAllPatients;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<PatientDTO>>
{
    private readonly IPatientRepository _patientRepository;

    public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<List<PatientDTO>> Handle(GetAllPatientsQuery request, CancellationToken token)
    {
        var patientsList = await _patientRepository.GetAllAsync(token);
        
        return patientsList
            .Select(m =>
                new PatientDTO(
                    m.FirstName,
                    m.LastName,
                    m.DateBirth,
                    m.ProfileId
                ))
            .ToList();
    }
}