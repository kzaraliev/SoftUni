using System.Text;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string output = GetSoldProducts(context);
            File.WriteAllText(@"../../../Results/users-sold-products.xml", output);
        }

        private static string Serializer<T>(T dataTransferObjects, string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            StringBuilder sb = new StringBuilder();
            using var write = new StringWriter(sb);

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

            return sb.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
           //var users = context.Users
           //    .Where(u => u.ProductsSold.Any())
           //    .OrderBy(u => u.LastName)
           //    .ThenBy(u => u.FirstName)
           //    .Take(5)
           //    .Select(u => new ExportUserWithSoldProductsDto()
           //    {
           //        FirstName = u.FirstName,
           //        LastName = u.LastName,
           //        SoldProducts = u.ProductsSold
           //            .Select(p => new ProductDto()
           //            {
           //                Name = p.Name,
           //                Price = p.Price
           //            }).ToList()
           //    })
           //    .ToList();
           //
           //return Serializer<List<ExportUserWithSoldProductsDto>>(users, "Users");

            ExportSoldProductsDto[] usersSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .ToArray();

            return Serializer<ExportSoldProductsDto[]>(usersSoldProducts, "Users");
        }
    }
}