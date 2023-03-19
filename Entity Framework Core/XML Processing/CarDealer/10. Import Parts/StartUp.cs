using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersFilePath = @"../../../Datasets/suppliers.xml";
            string suppliersXml = File.ReadAllText(suppliersFilePath);
            ImportSuppliers(context, suppliersXml);

            string partsFilePath = @"../../../Datasets/parts.xml";
            string partsXml = File.ReadAllText(partsFilePath);
            string output = ImportParts(context, partsXml);

            Console.WriteLine(output);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ImportSuppliersDto[] suppliersDtos = xmlHelper.Deserializer<ImportSuppliersDto[]>(inputXml, "Suppliers");

            Supplier[] suppliers = suppliersDtos
                .Select(s => new Supplier()
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ImportPartsDto[] partsDtos = xmlHelper.Deserializer<ImportPartsDto[]>(inputXml, "Parts");

            int[] supplierIds = context.Suppliers.Select(s => s.Id).ToArray();

            Part[] parts = partsDtos
                .Where(p => supplierIds.Contains(p.SupplierId))
                .Select(p => new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }
    }
}