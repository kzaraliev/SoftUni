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

            string output = GetTotalSalesByCustomer(context);
            File.WriteAllText(@"../../../Results/customers-total-sales.xml", output);
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

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var tempDto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                    }).ToArray(),
                })
                .ToArray();

            ExportCustomersWithCarsDto[] totalSalesDtos = tempDto
                .OrderByDescending(t => t.SalesInfo.Sum(s => s.Prices))
                .Select(t => new ExportCustomersWithCarsDto()
                {
                    Name = t.FullName,
                    CarsCount = t.BoughtCars,
                    TotalPrice = t.SalesInfo.Sum(s => s.Prices).ToString("f2")
                })
                .ToArray();

            return xmlHelper.Serializer<ExportCustomersWithCarsDto[]>(totalSalesDtos, "customers");
        }
    }
}