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

        //09. Book Search
        string input = Console.ReadLine();
        string result = GetBookTitlesContaining(db, input);

        Console.WriteLine(result);
    }

    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var books = context
            .Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var book in books)
        {
            sb.AppendLine(book);
        }

        return sb.ToString().TrimEnd();
    }
}