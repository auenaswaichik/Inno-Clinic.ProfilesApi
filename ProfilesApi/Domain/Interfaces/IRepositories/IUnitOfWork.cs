namespace Domain.Interfaces.IRepositories;

public interface IUnitOfWork
{
    void Save();
    Task SaveAsync(CancellationToken token);
    void Rollback();
}