using Domain.Entities;
using Domain.Entities.Parameters;

namespace Domain.Interfaces.IRepositories;

public interface ISpecializationRepository 
{
    public Task<List<Specialization>> GetAllAsync(SpecializationParameters parameters, CancellationToken token);
    public Specialization Insert(Specialization specialization);
    public Specialization Update(Specialization specialization);
    public void Delete(Specialization specialization);
    public Task<Specialization> GetByIdAsync(Guid id, CancellationToken token);
}