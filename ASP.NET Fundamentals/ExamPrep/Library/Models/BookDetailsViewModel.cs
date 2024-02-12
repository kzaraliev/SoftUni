namespace Library.Models
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel(int id, string title, string author, string imgUrl, string description, string category)
        {
            Id = id;
            Title = title;
            Author = author;
            ImageUrl = imgUrl;
            Description = description;
            Category = category;
        }

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Description { get; set; }

        public string Category { get; set; } = null!;
    }
}
