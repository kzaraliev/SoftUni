using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class ImportCarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("traveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartDto[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
