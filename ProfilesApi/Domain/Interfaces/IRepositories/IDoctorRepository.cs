using Domain.Entities;

namespace Domain.Interfaces.IRepositories;

public interface IDoctorRepository : IGenericRepository<Doctor>
{
    public Task<Doctor> GetByIdAsync(Guid id, CancellationToken token);
}