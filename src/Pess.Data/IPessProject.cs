using System.Collections.Generic;

namespace Pess.Data
{
    public interface IPessProject
    {
        ProjectId Id { get; }
        string Name { get; }
        string Description { get; }
        IEnumerable<IPessAggregate> Aggregates { get; }
    }
}