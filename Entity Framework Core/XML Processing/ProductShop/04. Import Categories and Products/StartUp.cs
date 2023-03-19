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
            ImportProducts(context, productInputXml);

            string categoriesXmlFilePath = @"../../../Datasets/categories.xml";
            string categoriesXml = File.ReadAllText(categoriesXmlFilePath);
            ImportCategories(context, categoriesXml);

            string categoryProductXmlFilePath = @"../../../Datasets/categories-products.xml";
            string categoryProductInputXml = File.ReadAllText(categoryProductXmlFilePath);
            string output = ImportCategoryProducts(context, categoryProductInputXml);

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

            var users = userDtos
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

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoryDtos = Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            var categories = categoryDtos
                .Where(c => c.Name != null)
                .Select(c => new Category()
                {
                    Name = c.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var catProdDtos = Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            var categoryProducts = catProdDtos
                .Where(cp => cp.CategoryId != null && cp.ProductId != null)
                .Select(cp => new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                })
                .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }
    }
}