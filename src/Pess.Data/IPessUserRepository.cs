using System;

namespace Pess.Data
{
    public interface IPessRepository
    {
        IPessAggregate CreateAggregateAsync(string name);


    }
}
