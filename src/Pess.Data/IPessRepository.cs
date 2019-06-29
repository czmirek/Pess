namespace Pess.Data
{
    using System.Collections.Generic;
    public interface IPessRepository
    {
        //projects
        ProjectId CreateProject(IPessProject newProject);
        IEnumerable<IPessProject> ListProjects();
        IPessProject GetProject(ProjectId projectId);

        //aggregates
        AggregateId CreateAggregate(IPessAggregate newAggregate);
        IEnumerable<IPessAggregate> ListAggregates();
        IEnumerable<IPessAggregate> ListAggregates(ProjectId projectId);
        IPessAggregate GetAggregate(AggregateId aggregateId);
    }
}
