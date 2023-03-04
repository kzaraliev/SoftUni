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

        //06. Book Titles by Category
        string categories = Console.ReadLine();
        string result = GetBooksByCategory(db, categories);

        Console.WriteLine(result);
    }
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

        var booksCategories = context
            .BooksCategories
            .Where(b => categories.Contains(b.Category.Name.ToLower()))
            .Select(b => new
            {
               Title = b.Book.Title
            })
            .OrderBy(b => b.Title)
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var book in booksCategories)
        {
            sb.AppendLine(book.Title);
        }

        return sb.ToString().TrimEnd();
    }
}