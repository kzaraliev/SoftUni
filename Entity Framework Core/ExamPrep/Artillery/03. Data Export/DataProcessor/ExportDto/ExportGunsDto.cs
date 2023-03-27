using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunsDto
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")]
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public string GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public string BarrelLength { get; set;}

        [XmlAttribute("Range")]
        public string Range { get; set;}

        [XmlArray("Countries")]
        public ExportCountriesDto[] Countries { get; set;}
    }

    [XmlType("Country")]
    public class ExportCountriesDto
    {
        [XmlAttribute("Country")]
        public string CountryName { get; set; }

        [XmlAttribute("ArmySize")]
        public string ArmySize { get; set; }
    }
}
