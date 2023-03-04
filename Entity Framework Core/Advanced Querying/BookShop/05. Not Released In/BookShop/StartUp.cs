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
        
        //05. Not Released In
        int year = int.Parse(Console.ReadLine());
        string result = GetBooksNotReleasedIn(db, year);
        Console.WriteLine(result);
    }

    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var books = context
            .Books
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                b.Title
            })
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            sb.AppendLine(book.Title);
        }

        return sb.ToString().TrimEnd();
    }
}