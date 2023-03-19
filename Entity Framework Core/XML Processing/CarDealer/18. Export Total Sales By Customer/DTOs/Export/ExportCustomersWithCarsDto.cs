using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("customer")]
    public class ExportCustomersWithCarsDto
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("bought-cars")]
        public int CarsCount { get; set; }

        [XmlAttribute("spent-money")]
        public string TotalPrice { get; set; }
    }
}
