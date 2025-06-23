using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(ProfilesApiDbContext context) : base(context)
    {
        
    }
}
