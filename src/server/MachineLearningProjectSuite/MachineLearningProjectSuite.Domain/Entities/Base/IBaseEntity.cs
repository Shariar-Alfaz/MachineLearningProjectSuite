namespace MachineLearningProjectSuite.Domain.Entities.Base
{
    public interface IBaseEntity<TKey>
        where TKey : IComparable
    {
        TKey Id { get; set; }
    }
}
