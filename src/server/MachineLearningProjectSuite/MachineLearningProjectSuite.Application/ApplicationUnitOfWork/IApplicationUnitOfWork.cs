using MachineLearningProjectSuite.Application.Feature.Repository.Property;
using MachineLearningProjectSuite.Domain.UnitOfWork;

namespace MachineLearningProjectSuite.Application.ApplicationUnitOfWork
{
    public interface IApplicationUnitOfWork : IBaseUnitOfWork
    {
        IPropertyListingRepository PropertyListingRepository { get; }
    }
}
