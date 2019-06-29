namespace Pess.Data.Xml
{
    using System.Runtime.Serialization;

    [DataContract]
    internal class Aggregate : IPessAggregate
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [IgnoreDataMember]
        AggregateId IPessAggregate.Id { get => (AggregateId)Id; }
    }
}