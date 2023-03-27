
using System.Globalization;
using System.Linq;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ExportDto;
using CarDealer;
using Newtonsoft.Json;

namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using System;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .ToArray()
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = Math.Round(s.ShellWeight, 1),
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType == GunType.AntiAircraftGun)
                        .OrderByDescending(g => g.GunWeight)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = Math.Round(g.BarrelLength, 2),
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var guns = context.Guns
                .ToArray()
                .Where(g => g.Manufacturer.ManufacturerName.ToString() == manufacturer)
                .OrderBy(g => g.BarrelLength)
                .Select(g => new ExportGunsDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName.ToString(),
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight.ToString(),
                    BarrelLength = Math.Round(g.BarrelLength, 2).ToString(CultureInfo.InvariantCulture),
                    Range = g.Range.ToString(CultureInfo.InvariantCulture),
                    Countries = g.CountriesGuns
                        .Where(c => c.Country.ArmySize > 4500000)
                        .Select(c => new ExportCountriesDto()
                        {
                            CountryName = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize.ToString()
                        })
                        .OrderBy(c => c.ArmySize)
                        .ToArray()
                })
                .ToArray();

            return xmlHelper.Serializer(guns, "Guns");
        }
    }
}
