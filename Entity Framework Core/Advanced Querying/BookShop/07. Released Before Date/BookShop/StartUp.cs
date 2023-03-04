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

        //07. Released Before Date
        string date = Console.ReadLine();
        string result = GetBooksReleasedBefore(db, date);

        Console.WriteLine(result);
    }

    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

        var books = context
            .Books
            .Where(b => b.ReleaseDate < dateTime)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.ReleaseDate,
                b.Price
            })
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }
}