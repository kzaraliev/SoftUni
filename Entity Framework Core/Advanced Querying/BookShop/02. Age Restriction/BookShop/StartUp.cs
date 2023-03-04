using BookShop.Models.Enums;

namespace BookShop;

using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();

        //02. Age Restriction
        string input = Console.ReadLine();
        string output = GetBooksByAgeRestriction(db, input);

        Console.WriteLine(output);
    }

    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        var enumValue = Enum.Parse<AgeRestriction>(command, true);

        var books = context
            .Books
            .Where(b => b.AgeRestriction == enumValue)
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToList();

        return String.Join(Environment.NewLine, books).TrimEnd();
    }
}