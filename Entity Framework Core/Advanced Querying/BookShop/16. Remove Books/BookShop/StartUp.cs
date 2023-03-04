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

        Console.WriteLine(RemoveBooks(db));
    }

    public static int RemoveBooks(BookShopContext context)
    {
        var booksToRemove = context
            .Books
            .Where(b => b.Copies < 4200)
            .ToList();

        context.RemoveRange(booksToRemove);
        context.SaveChanges();

        return booksToRemove.Count();
    }
}