namespace Domain.Interfaces.IRepositories;

public interface IUnitOfWork
{
    void Rollback();
    Task SaveAsync();
    void Save();
}