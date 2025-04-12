using MachineLearningProjectSuite.Domain.Entities.Property;

namespace MachineLearningProjectSuite.Application.Utility.Seeder
{
    public interface IPropertyDataSeeder
    {
        List<PropertyListing> GetData();
    }
}
