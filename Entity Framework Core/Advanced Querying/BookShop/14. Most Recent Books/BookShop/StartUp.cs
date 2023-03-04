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

        Console.WriteLine(GetMostRecentBooks(db));
    }

    public static string GetMostRecentBooks(BookShopContext context)
    {
        var books = context
            .Categories
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                CategoryName = c.Name,
                Books = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        BookYear = cb.Book.ReleaseDate.Value.Year
                    })
                    .Take(3)
            })
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var book1 in books)
        {
            sb.AppendLine($"--{book1.CategoryName}");
            foreach (var book in book1.Books)
            {
                sb.AppendLine($"{book.BookTitle} ({book.BookYear})");
            }
        }

        return sb.ToString().TrimEnd();
    }
}