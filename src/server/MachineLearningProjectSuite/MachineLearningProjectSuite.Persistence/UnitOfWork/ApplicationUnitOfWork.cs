using MachineLearningProjectSuite.Application.ApplicationUnitOfWork;
using MachineLearningProjectSuite.Application.Feature.Repository.Property;
using MachineLearningProjectSuite.Persistence.Database.Base;
using MachineLearningProjectSuite.Persistence.UnitOfWork.Base;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningProjectSuite.Persistence.UnitOfWork
{
    public class ApplicationUnitOfWork(
        IApplicationDbContext context,
        IPropertyListingRepository propertyListingRepository)
        : BaseUnitOfWork((DbContext)context),
            IApplicationUnitOfWork
    {
        public IPropertyListingRepository PropertyListingRepository => propertyListingRepository;
    }
}
