using MachineLearningProjectSuite.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningProjectSuite.Persistence.UnitOfWork.Base
{
    public class BaseUnitOfWork(DbContext context) : IBaseUnitOfWork
    {
        public void Dispose() => context.Dispose();


        public async ValueTask DisposeAsync() => await context.DisposeAsync();


        public void SaveChanges() => context.SaveChanges();


        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

    }
}
