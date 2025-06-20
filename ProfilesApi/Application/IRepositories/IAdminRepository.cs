using Domain.Entities;

namespace Application.IRepositories;

public interface IAdminRepository
{
    public Task<List<Admin>> GetAdmins();
    public Task<Admin> GetAdmin(Guid id);
    public Task RemoveAdmin(Guid id);
    public Task<Admin> CreateAdmin(Admin admin);
    public Task<Admin> UpdateAdmin(Guid id, Admin admin);
}