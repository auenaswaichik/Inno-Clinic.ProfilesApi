using Domain.Entities;

namespace Application.IRepositories;

public interface IPatientRepository
{
    public Task<List<Patient>> GetPatients();
    public Task<Patient> GetPatient(Guid id);
    public Task RemovePatient(Guid id);
    public Task<Patient> CreatePatient(Patient patient);
    public Task<Patient> UpdatePatient(Guid id, Patient patient);
}