namespace MachineLearningProjectSuite.Application.Dto.Property
{
    public class InitRequestModel
    {
        public IList<AddressDto> Addresses { get; set; }
        public IList<TypeDto> Types { get; set; }
    }
}
