using System.Globalization;
using CsvHelper;
using MachineLearningProjectSuite.Application.Utility.Seeder;
using MachineLearningProjectSuite.Domain.Entities.Property;

namespace MachineLearningProjectSuite.Persistence.Utility.Seeder
{
    public class PropertyDataSeeder : IPropertyDataSeeder
    {
        public List<PropertyListing> GetData()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "updated_property.csv");
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<PropertyData>().ToList();
            return records.Select(record => new PropertyListing
            {
                Id = Guid.NewGuid(),
                Title = record.Title,
                Beds = record.Beds,
                Bath = record.Bath,
                Area = record.Area,
                Address = record.Address,
                Type = record.Type,
                Purpose = record.Purpose,
                FloorPlan = record.FloorPlan,
                Url = record.Url,
                Price = record.Price,
                AddressValue = record.AddressValue,
                TypeValue = record.TypeValue
            }).ToList();
        }
    }

    internal class PropertyData
    {
        public string Title { get; set; }
        public int Beds { get; set; }
        public int Bath { get; set; }
        public double Area { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Purpose { get; set; }
        public string FloorPlan { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public int AddressValue { get; set; }
        public int TypeValue { get; set; }
    }
}
