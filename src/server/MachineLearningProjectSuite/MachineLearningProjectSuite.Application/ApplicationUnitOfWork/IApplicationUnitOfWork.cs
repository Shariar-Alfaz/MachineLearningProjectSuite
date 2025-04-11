using MachineLearningProjectSuite.Application.Feature.Repository;
using MachineLearningProjectSuite.Domain.UnitOfWork;

namespace MachineLearningProjectSuite.Application.ApplicationUnitOfWork
{
    public interface IApplicationUnitOfWork : IBaseUnitOfWork
    {
        IPropertyListingRepository PropertyListingRepository { get; }
    }
}
