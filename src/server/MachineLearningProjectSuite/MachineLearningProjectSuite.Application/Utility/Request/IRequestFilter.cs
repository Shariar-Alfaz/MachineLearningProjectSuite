namespace MachineLearningProjectSuite.Application.Utility.Request
{
    public interface IRequestFilter
    {
        string Search { get; }
        int PageSize { get; }
        DateTime? EndDate { get; }
        string Filter { get; }
        string NestedOrder { get; }
        int Skip { get; }
        string SortColumn { get; }
        DateTime? StartDate { get; }

        T GetData<T>(string key) where T : IComparable;
    }
}
