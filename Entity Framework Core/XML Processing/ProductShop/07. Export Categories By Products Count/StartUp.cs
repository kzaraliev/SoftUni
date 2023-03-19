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

            string output = GetCategoriesByProductsCount(context);
            File.WriteAllText(@"../../../Results/categories-by-products.xml", output);
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

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesByProducts[] categories = context.Categories
                .Select(c => new ExportCategoriesByProducts()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price),
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            return Serializer<ExportCategoriesByProducts[]>(categories, "Categories");
        }
    }
}