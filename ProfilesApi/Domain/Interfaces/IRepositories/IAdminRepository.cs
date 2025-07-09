using Domain.Entities;

namespace Domain.Interfaces.IRepositories;

public interface IAdminRepository : IGenericRepository<Admin>
{
    public Task<Admin> GetByIdAsync(Guid id, CancellationToken token);
}