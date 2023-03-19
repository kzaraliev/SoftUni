using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;
using CarDealer.DTOs.Export;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            string output = GetCarsWithTheirListOfParts(context);
            File.WriteAllText(@"../../../Results/cars-and-parts.xml", output);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarsWithPartsDto[] cars = context.Cars
                .Select(c => new ExportCarsWithPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .Select(p => new Parts()
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            return xmlHelper.Serializer(cars, "cars");
        }
    }
}