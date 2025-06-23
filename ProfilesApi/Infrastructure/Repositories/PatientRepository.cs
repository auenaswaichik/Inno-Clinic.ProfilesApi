using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public PatientRepository(ProfilesApiDbContext context) : base(context)
    {
        
    }
}

