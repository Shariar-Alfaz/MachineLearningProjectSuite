namespace MachineLearningProjectSuite.Domain.UnitOfWork
{
    public interface IBaseUnitOfWork : IDisposable, IAsyncDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
