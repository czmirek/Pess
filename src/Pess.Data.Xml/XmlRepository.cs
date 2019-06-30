namespace Pess.Data.Xml
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml;

    public class PessXmlRepository : IPessRepository
    {
        private static readonly Root root = new Root()
        {
            Aggregates = new List<Aggregate>(),
            Projects = new List<Project>()
        };
        private static readonly IMapper mapper;
        private static readonly object repoLock = new object();
        private const string xmlFile = "pess_data.xml";
        static PessXmlRepository()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IPessAggregate, Aggregate>();
                cfg.CreateMap<IPessProject, Project>();
            }).CreateMapper();

            if (File.Exists(xmlFile))
            {
                using (FileStream fs = new FileStream(xmlFile, FileMode.Open))
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {
                    DataContractSerializer ser = new DataContractSerializer(typeof(Root));
                    root = (Root)ser.ReadObject(reader, true);
                }
            }
        }

        public AggregateId CreateAggregate(IPessAggregate newAggregate)
        {
            AggregateId newId = (AggregateId)Guid.NewGuid().ToString();

            Aggregate aggregateModel = mapper.Map<Aggregate>(newAggregate);
            aggregateModel.Id = newId.Value;

            root.Aggregates.Add(aggregateModel);
            Save();

            return newId;
        }

        public ProjectId CreateProject(IPessProject newProject)
        {
            ProjectId newId = (ProjectId)Guid.NewGuid().ToString();

            Project projectModel = mapper.Map<Project>(newProject);
            projectModel.Id = newId.Value;

            root.Projects.Add(projectModel);
            Save();

            return newId;
        }

        public IPessAggregate GetAggregate(AggregateId aggregateId)
            => root.Aggregates.FirstOrDefault(a => ((IPessAggregate)a).Id == aggregateId);

        public IPessProject GetProject(ProjectId projectId)
            => root.Projects.FirstOrDefault(a => ((IPessProject)a).Id == projectId);

        public IEnumerable<IPessAggregate> ListAggregates()
            => root.Aggregates;

        public IEnumerable<IPessProject> ListProjects()
            => root.Projects;

        public IEnumerable<IPessAggregate> ListAggregates(ProjectId projectId)
            => root.Aggregates.Where(a => ((IPessAggregate)a).ProjectId == projectId);

        private void Save()
        {
            lock (repoLock)
            {
                using (FileStream writer = new FileStream(xmlFile, FileMode.Create))
                {
                    DataContractSerializer ser = new DataContractSerializer(typeof(Root));
                    ser.WriteObject(writer, root);
                }

            }
        }
    }
}
