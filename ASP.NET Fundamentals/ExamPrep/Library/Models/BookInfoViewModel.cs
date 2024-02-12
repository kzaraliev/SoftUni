using Library.Data.Models;
using Library.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookInfoViewModel
    {
        public BookInfoViewModel(int id, string title, string author, string imgUrl, decimal rating, string category)
        {
            Id = id;
            Title = title;
            Author = author;
            ImageUrl = imgUrl;
            Rating = rating;
            Category = category;
        }

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public decimal Rating { get; set; }

        public string Category { get; set; } = null!;
    }
}
