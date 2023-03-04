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

        //10. Book Search by Author
        string input = Console.ReadLine();
        string result = GetBooksByAuthor(db, input);
        
        Console.WriteLine(result);
    }

    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var books = context
            .Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                b.Title,
                AuthorNames = b.Author.FirstName + " " + b.Author.LastName
            })
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} ({book.AuthorNames})");
        }

        return sb.ToString().TrimEnd();
    }
}