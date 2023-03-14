using System.Xml;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string print = GetTotalSalesByCustomer(context);
            string filePath = @"../../../Results/customers-total-sales.json";
            File.WriteAllText(filePath, print);
        }
        
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersSales = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price))
                })
                .ToList();

            var totalSales = customersSales.Select(c => new
                {
                    c.fullName,
                    c.boughtCars,
                    spentMoney = c.spentMoney.Sum()
                })
                .OrderByDescending(t => t.spentMoney)
                .ThenByDescending(t => t.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(totalSales, Formatting.Indented);
        }
    }
}