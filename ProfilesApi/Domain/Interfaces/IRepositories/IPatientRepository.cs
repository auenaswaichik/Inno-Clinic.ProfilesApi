using Domain.Entities;

namespace Domain.Interfaces.IRepositories;

public interface IPatientRepository : IGenericRepository<Patient>
{
    public Task<Patient> GetByIdAsync(Guid id, CancellationToken token);
}