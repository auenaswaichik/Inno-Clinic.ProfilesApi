using Domain.Entities;
using Domain.Entities.Extensions;
using Domain.Entities.Parameters;
using Domain.RequestFeatures;

namespace Domain.Interfaces.IRepositories;

public interface ISpecializationRepository 
{
    public Task<PagedList<Specialization>> GetAllAsync(SpecializationParameters parameters, CancellationToken token);
    public Task CreateAsync(Specialization specialization, CancellationToken token);
    public void Update(Specialization specialization);
    public void Delete(Specialization specialization);
    public Task<Specialization> GetByIdAsync(Guid id, CancellationToken token);
}