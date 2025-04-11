using MachineLearningProjectSuite.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningProjectSuite.Persistence.Database.Base
{
    public interface IApplicationDbContext
    {
        DbSet<PropertyListing> PropertyListings { get; set; }
    }
}
