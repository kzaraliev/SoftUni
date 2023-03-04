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

        Console.WriteLine(GetGoldenBooks(db));
    }

    public static string GetGoldenBooks(BookShopContext context)
    {
        var books = context
            .Books
            .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }
}