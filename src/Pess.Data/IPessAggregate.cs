namespace Pess.Data
{
    public interface IPessAggregate
    {
        AggregateId Id { get; }
        ProjectId ProjectId { get; }
        string Name { get; }
        string Description { get; }
    }
}