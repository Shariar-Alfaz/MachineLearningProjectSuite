using MachineLearningProjectSuite.Domain.Entities.Base;

namespace MachineLearningProjectSuite.Domain.Entities
{
    public class PropertyListing : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
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
        public string AddressValue { get; set; }
        public string TypeValue { get; set; }
    }
}
