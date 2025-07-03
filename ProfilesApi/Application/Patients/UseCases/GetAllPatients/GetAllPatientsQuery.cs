using Application.Patients.Models;
using MediatR;

namespace Application.Patients.UseCases.GetAllPatients;

public class GetAllPatientsQuery : IRequest<List<PatientDTO>>;