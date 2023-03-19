using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string userXmlFilePath = @"../../../Datasets/users.xml";
            string inputXml = File.ReadAllText(userXmlFilePath);
            ImportUsers(context, inputXml);

            string productXmlFilePath = @"../../../Datasets/products.xml";
            string productInputXml = File.ReadAllText(productXmlFilePath);
            string output = ImportProducts(context, productInputXml);
            Console.WriteLine(output);
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var userDtos = Deserialize<ImportUserDto[]>(inputXml, "Users");

            User[] users = userDtos
                .Select(s => new User()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productDtos = Deserialize<ImportProductDto[]>(inputXml, "Products");

            var products = productDtos
                .Select(p => new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerId = p.BuyerId == 0 ? null : p.BuyerId,
                    SellerId = p.SellerId
                })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

           return $"Successfully imported {products.Count()}";
        }
    }
}