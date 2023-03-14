using System.Xml;
using CarDealer.Data;
using CarDealer.DTOs.Import;
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
            ImportParts(context, inputJsonParts);

            string inputJsonCars = File.ReadAllText(@"../../../Datasets/cars.json");
            ImportCars(context, inputJsonCars);

            string inputJsonCustomers = File.ReadAllText(@"../../../Datasets/customers.json");
            ImportCustomers(context, inputJsonCustomers);

            string inputJsonSales = File.ReadAllText(@"../../../Datasets/sales.json");
            string output = ImportSales(context, inputJsonSales);

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

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsAndParts = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            List<PartCar> parts = new List<PartCar>();
            List<Car> cars = new List<Car>();

            foreach (var dto in carsAndParts)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance
                };

                cars.Add(car);
                foreach (var part in dto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part
                    };

                    parts.Add(partCar);
                }
            }


            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
    }
}