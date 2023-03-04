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

        Console.WriteLine(GetTotalProfitByCategory(db));
    }

    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var bookCategories = context
            .Categories
            .OrderByDescending(c => c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price))
            .ThenBy(c => c.Name)
            .Select(c => $"{c.Name} ${c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price):f2}")
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var bookCategory in bookCategories)
        {
            sb.AppendLine(bookCategory);
        }

        return sb.ToString().TrimEnd();
    }
}