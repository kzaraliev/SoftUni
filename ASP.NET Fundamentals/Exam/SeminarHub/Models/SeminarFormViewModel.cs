using Microsoft.AspNetCore.Identity;
using SeminarHub.Data.Models;
using SeminarHub.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    public class SeminarFormViewModel
    {
        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        [StringLength(DataConstants.TopicMaxLength, MinimumLength = DataConstants.TopicMinLength, ErrorMessage = ErrorConstants.StringLengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        [StringLength(DataConstants.LecturerMaxLength, MinimumLength = DataConstants.LecturerMinLength, ErrorMessage = ErrorConstants.StringLengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        [StringLength(DataConstants.DetailsMaxLength, MinimumLength = DataConstants.DetailsMinLength, ErrorMessage = ErrorConstants.StringLengthErrorMessage)]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        public string DateAndTime { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        public string Duration { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
