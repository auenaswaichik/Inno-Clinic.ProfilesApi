using Domain.Entities;
using Domain.Entities.Extensions;
using Domain.RequestFeatures;

namespace Domain.Interfaces.IRepositories;

public interface IAdminRepository : IGenericRepository<Admin>
{
    public Task<Admin> GetByIdAsync(Guid id, CancellationToken token);
    public Task<PagedList<Admin>> GetDoctorsAsync(AdminParameters adminParameters, CancellationToken token);
}