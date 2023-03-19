using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;
using CarDealer.DTOs.Export;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            string output = GetCarsWithDistance(context);
            File.WriteAllText(@"../../../Results/cars.xml", output);
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ExportCarsWithDistanceDto[] carsDtos = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            return xmlHelper.Serializer(carsDtos, "cars");
        }
    }
}