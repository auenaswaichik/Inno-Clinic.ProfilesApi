using Domain.Interfaces.IRepositories;
using Domain.Entities;

namespace Domain.Interfaces.IManagers;

public interface IUnitOfWork
{

    void BeginTransaction();

    void Rollback();

    Task SaveAsync();

    void Save();

}