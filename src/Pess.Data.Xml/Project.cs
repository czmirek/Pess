namespace Pess.Data.Xml
{
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

        [IgnoreDataMember]
        ProjectId IPessProject.Id { get => (ProjectId)Id; }
    }
}