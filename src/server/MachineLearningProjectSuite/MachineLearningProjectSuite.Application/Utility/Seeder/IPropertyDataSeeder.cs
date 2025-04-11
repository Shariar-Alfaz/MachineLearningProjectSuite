using MachineLearningProjectSuite.Domain.Entities;

namespace MachineLearningProjectSuite.Application.Utility.Seeder
{
    public interface IPropertyDataSeeder
    {
        List<PropertyListing> GetData();
    }
}
