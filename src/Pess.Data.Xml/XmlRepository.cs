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
        private static readonly Dictionary<ProjectId, Project> projects = new Dictionary<ProjectId, Project>();
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
                    Root pessXmlRoot = (Root)ser.ReadObject(reader, true);
                    projects = pessXmlRoot.Projects.ToDictionary(k => ((IPessProject)k).Id);
                }
            }
        }

        public AggregateId CreateAggregate(IPessAggregate newAggregate)
        {
            throw new NotImplementedException();
        }

        public IPessAggregate CreateAggregateAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public ProjectId CreateProject(IPessProject newProject)
        {
            throw new System.NotImplementedException();
        }

        public IPessAggregate GetAggregate(AggregateId aggregateId)
        {
            throw new System.NotImplementedException();
        }

        public IPessProject GetProject(ProjectId projectId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IPessAggregate> ListAggregates()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IPessProject> ListProjects()
        {
            throw new System.NotImplementedException();
        }

        private void Save()
        {
            lock (repoLock)
            {
                Root xmlRoot = new Root()
                {
                    Projects = projects.Values.ToList()
                };
                using (FileStream writer = new FileStream(xmlFile, FileMode.Create))
                {
                    DataContractSerializer ser = new DataContractSerializer(typeof(Root));
                    ser.WriteObject(writer, xmlRoot);
                }

            }
        }

        public IEnumerable<IPessAggregate> ListAggregates(ProjectId projectId)
        {
            throw new NotImplementedException();
        }
    }
}
