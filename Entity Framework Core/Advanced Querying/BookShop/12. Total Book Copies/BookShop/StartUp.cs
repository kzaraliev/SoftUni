using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;

namespace BookShop;

using Data;
using Initializer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();

        Console.WriteLine(CountCopiesByAuthor(db));
    }
    
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var authorsWithBooks = context
            .Authors
            .OrderByDescending(a => a.Books.Sum(b => b.Copies))
            .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var authorsWithBook in authorsWithBooks)
        {
            sb.AppendLine(authorsWithBook);
        }

        return sb.ToString().TrimEnd();
    }
}