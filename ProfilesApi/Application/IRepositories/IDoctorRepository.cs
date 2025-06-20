using Domain.Entities;

namespace Application.IRepositories;

public interface IDoctorRepository
{
    public Task<List<Doctor>> GetDoctors();
    public Task<Doctor?> GetDoctor(Guid id);
    public Task RemoveDoctor(Guid id);
    public Task<Doctor> CreateDoctor(Doctor doctor);
    public Task<Doctor> UpdateDoctor(Guid id, Doctor doctor);
}