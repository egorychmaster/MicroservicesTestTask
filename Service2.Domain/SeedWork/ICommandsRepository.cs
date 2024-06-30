namespace Service2.Domain.SeedWork
{
    public interface ICommandsRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}