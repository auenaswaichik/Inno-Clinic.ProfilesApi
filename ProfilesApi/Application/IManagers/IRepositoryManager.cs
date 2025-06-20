using Application.IRepositories;

namespace Application.IManagers;

public interface IRepositoryManager
{
    IPatientRepository PatientRepository { get; }
    IDoctorRepository DoctorRepository { get; }
    IAdminRepository AdminRepository { get; }
    Task SaveAsync();
    void Save();
}