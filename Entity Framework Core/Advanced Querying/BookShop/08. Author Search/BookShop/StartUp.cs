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

        //08. Author Search
        string input = Console.ReadLine();
        string result = GetAuthorNamesEndingIn(db, input);

        Console.WriteLine(result);
    }

    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authors = context
            .Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => a.FirstName + " " + a.LastName)
            .OrderBy(name => name)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var author in authors)
        {
            sb.AppendLine(author);
        }

        return sb.ToString().TrimEnd();
    }
}