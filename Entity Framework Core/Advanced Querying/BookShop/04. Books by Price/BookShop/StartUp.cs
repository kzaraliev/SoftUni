using System.Text;
using BookShop.Models.Enums;

namespace BookShop;

using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        
        Console.WriteLine(GetBooksByPrice(db));
    }

    public static string GetBooksByPrice(BookShopContext context)
    {
        var books = context
            .Books
            .Where(b => b.Price > 40)
            .Select(b => new
            {
                b.Title,
                b.Price
            })
            .OrderByDescending(b => b.Price)
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }
}