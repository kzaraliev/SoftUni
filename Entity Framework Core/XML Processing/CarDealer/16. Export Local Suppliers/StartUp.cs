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

            string output = GetLocalSuppliers(context);
            File.WriteAllText(@"../../../Results/local-suppliers.xml", output);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportLocalSuppliersDto[] suppliersDtos = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return xmlHelper.Serializer(suppliersDtos, "suppliers");
        }
    }
}