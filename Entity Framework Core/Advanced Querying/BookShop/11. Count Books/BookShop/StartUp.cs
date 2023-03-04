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

        //11. Count Books
        int input = int.Parse(Console.ReadLine());
        int result = CountBooks(db, input);

        Console.WriteLine(result);
    }

    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        var books = context
            .Books
            .Where(b => b.Title.Length > lengthCheck)
            .Select(b => b.BookId)
            .ToList();
        
        return books.Count;
    }
}