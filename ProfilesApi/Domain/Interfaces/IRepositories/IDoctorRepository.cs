using Domain.Entities;
using Domain.Entities.Extensions;
using Domain.RequestFeatures;

namespace Domain.Interfaces.IRepositories;

public interface IDoctorRepository : IGenericRepository<Doctor>
{
    public Task<Doctor> GetByIdAsync(Guid id, CancellationToken token);
    public Task<PagedList<Doctor>> GetDoctorsAsync(DoctorParameters doctorParameters, CancellationToken token);
}