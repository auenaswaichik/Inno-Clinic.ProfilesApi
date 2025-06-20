using Application.IManagers;
using Application.IRepositories;
using Infrastructure.Data.DbContexts;
using Infrastructure.Repositories;

namespace Infrastructure.Mangers;
public class RepositoryManager : IRepositoryManager
{
    private readonly ProfilesApiDbContext _context;
    private readonly Lazy<IPatientRepository> _patientRepository;
    private readonly Lazy<IDoctorRepository> _doctorRepository;
    private readonly Lazy<IAdminRepository> _adminRepository;
    public RepositoryManager(ProfilesApiDbContext context)
    {
        _context = context;
        _patientRepository = new Lazy<IPatientRepository>(new PatientRepository(context));
        _doctorRepository = new Lazy<IDoctorRepository>(new DoctorRepository(context));
        _adminRepository = new Lazy<IAdminRepository>(new AdminRepository(context));
    }
    public IPatientRepository PatientRepository => _patientRepository.Value;
    public IDoctorRepository DoctorRepository => _doctorRepository.Value;
    public IAdminRepository AdminRepository => _adminRepository.Value;
    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
