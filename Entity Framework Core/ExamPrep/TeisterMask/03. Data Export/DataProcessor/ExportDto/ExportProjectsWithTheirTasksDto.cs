using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectsWithTheirTasksDto
    {
        [XmlAttribute("TasksCount")]
        public int Count { get; set; }

        [XmlElement("ProjectName")]
        public string Name { get; set; }

        [XmlElement("HasEndDate")]
        public string? HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public TasksForProjects[] TasksForProjects { get; set; }
    }

    [XmlType("Task")]
    public class TasksForProjects
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}
