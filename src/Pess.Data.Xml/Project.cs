namespace Pess.Data.Xml
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    internal class Project : IPessProject
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<Aggregate> Aggregates { get; set; }

        [IgnoreDataMember]
        ProjectId IPessProject.Id { get => (ProjectId)Id; }

        [IgnoreDataMember]
        IEnumerable<IPessAggregate> IPessProject.Aggregates => Aggregates.Select(a => a as IPessAggregate);
    }
}