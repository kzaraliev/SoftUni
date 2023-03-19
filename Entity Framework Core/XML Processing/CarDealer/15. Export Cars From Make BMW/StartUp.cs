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

            string output = GetCarsFromMakeBmw(context);
            File.WriteAllText(@"../../../Results/bmw-cars.xml", output);
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ExpoerCarsFromBMW[] carsDtos = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExpoerCarsFromBMW()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            return xmlHelper.Serializer(carsDtos, "cars");
        }
    }
}