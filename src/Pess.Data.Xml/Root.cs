namespace Pess.Data.Xml
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    internal class Root
    {
        [DataMember]
        public List<Project> Projects { get; set; }

        [DataMember]
        public List<Aggregate> Aggregates { get; set; }
    }
}
