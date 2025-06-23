using Domain.Interfaces.IRepositories;
using Domain.Entities;

namespace Domain.Interfaces.IManagers;

public interface IRepositoryManager
{
    Task SaveAsync();
    void Save();
}