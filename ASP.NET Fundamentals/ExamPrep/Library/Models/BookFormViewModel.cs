using Library.Data;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookFormViewModel
    {
        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        [StringLength(DataConstants.BookTitleMaxLength, MinimumLength = DataConstants.BookTitleMinLength, ErrorMessage = ErrorConstants.StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        [StringLength(DataConstants.BookAuthorMaxLength, MinimumLength = DataConstants.BookAuthorMinLength, ErrorMessage = ErrorConstants.StringLengthErrorMessage)]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        [StringLength(DataConstants.BookDescriptionMaxLength, MinimumLength = DataConstants.BookDescriptionMinLength, ErrorMessage = ErrorConstants.StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        public string Url { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        public string Rating { get; set; } = null!;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
