using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class ExportCarsWithPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;

        [XmlAttribute("model")]
        public string Model { get; set; } = null!;

        [XmlAttribute("traveled-distance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public Parts[] Parts { get; set; }
    }

    [XmlType("part")]
    public class Parts
    {
        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
