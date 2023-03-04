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
    }

    public static void IncreasePrices(BookShopContext context)
    {
        var books = context
            .Books
            .Where(b => b.ReleaseDate.Value.Year < 2010)
            .ToList();

        foreach (var book in books)
        {
            book.Price += 5;
        }
    }
}