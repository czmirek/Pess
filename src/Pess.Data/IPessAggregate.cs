namespace Pess.Data
{
    public interface IPessAggregate
    {
        AggregateId Id { get; }
        string Name { get; }
        string Description { get; }
    }
}