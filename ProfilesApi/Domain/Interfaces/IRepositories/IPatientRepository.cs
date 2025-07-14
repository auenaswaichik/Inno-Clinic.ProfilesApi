using Domain.Entities;
using Domain.Entities.Extensions;
using Domain.RequestFeatures;

namespace Domain.Interfaces.IRepositories;

public interface IPatientRepository : IGenericRepository<Patient>
{
    public Task<Patient> GetByIdAsync(Guid id, CancellationToken token);
    public Task<PagedList<Patient>> GetDoctorsAsync(PatientParameters patientParameters, CancellationToken token);

}