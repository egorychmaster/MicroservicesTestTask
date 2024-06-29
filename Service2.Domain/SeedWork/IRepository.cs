namespace Service2.Domain.SeedWork
{
    public interface IRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}