namespace MachineLearningProjectSuite.Application.Dto.Response
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }
        public ICollection<T> ListData { get; set; }
        public int TotalRecords { get; set; }
    }
}
