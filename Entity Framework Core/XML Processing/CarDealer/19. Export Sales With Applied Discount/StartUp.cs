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

            string output = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(@"../../../Results/sales-discounts.xml", output);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportSalesDto[] salesDtos = context.Sales
                .Select(s => new ExportSalesDto()
                {
                    Car = new CarToSale()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },

                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Select(p => p.Part.Price).Sum(),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)

                })
                .ToArray();

            return xmlHelper.Serializer(salesDtos, "sales");
        }
    }
}