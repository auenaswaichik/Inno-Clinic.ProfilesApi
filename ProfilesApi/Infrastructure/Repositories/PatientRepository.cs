using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{

    public PatientRepository(ProfilesApiDbContext context) : base(context)
    {

    }

}

