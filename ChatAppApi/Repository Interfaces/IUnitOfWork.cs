namespace ChatAppApi.Repository_Interfaces
{
    public interface IUnitOfWork : IReadOnlyUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
