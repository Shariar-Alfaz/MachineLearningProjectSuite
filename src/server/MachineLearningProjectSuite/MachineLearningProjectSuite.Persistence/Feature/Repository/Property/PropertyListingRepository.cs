using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineLearningProjectSuite.Application.Feature.Repository.Property;
using MachineLearningProjectSuite.Domain.Entities.Property;
using MachineLearningProjectSuite.Persistence.Database.Base;
using MachineLearningProjectSuite.Persistence.Feature.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningProjectSuite.Persistence.Feature.Repository.Property
{
    public class PropertyListingRepository(IApplicationDbContext context)
        : BaseRepository<PropertyListing, Guid>((DbContext)context),
            IPropertyListingRepository
    {
    }
}
