namespace Pess.Data.Xml
{
    using System.Runtime.Serialization;

    [DataContract]
    internal class Aggregate : IPessAggregate
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string ProjectId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [IgnoreDataMember]
        ProjectId IPessAggregate.ProjectId => (ProjectId)ProjectId;

        [IgnoreDataMember]
        AggregateId IPessAggregate.Id { get => (AggregateId)Id; }
    }
}