using MachineLearningProjectSuite.Domain.Entities.Property;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningProjectSuite.Persistence.Database.Base
{
    public interface IApplicationDbContext
    {
        DbSet<PropertyListing> PropertyListings { get; set; }
    }
}
