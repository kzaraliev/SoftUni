using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputJsonSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");
            ImportSuppliers(context, inputJsonSuppliers);

            string inputJsonParts = File.ReadAllText(@"../../../Datasets/parts.json");
            string output = ImportParts(context, inputJsonParts);

            Console.WriteLine(output);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
                
            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
           List<int> suppliers = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => suppliers.Contains(p.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }
    }
}