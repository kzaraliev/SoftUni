using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachesWithTheirFootballersDto
    {
        [XmlElement("CoachName")]
        public string CoachName { get; set; }

        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlArray("Footballers")]
        public FootballersDto[] Footballers { get; set; }
    }

    [XmlType("Footballer")]
    public class FootballersDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }
    }
}