using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AdminRepository : GenericRepository<Admin>, IAdminRepository
{
    public AdminRepository(ProfilesApiDbContext context) : base(context)
    {
 
    }
}
