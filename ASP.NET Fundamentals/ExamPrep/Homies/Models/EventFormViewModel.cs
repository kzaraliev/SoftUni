using Homies.Data;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class EventFormViewModel
    {
        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        [StringLength(DataConstants.EventNameMaxLength, MinimumLength = DataConstants.EventNameMinLength, ErrorMessage = ErrorConstants.StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        [StringLength(DataConstants.EventDescriptionMaxLength, MinimumLength = DataConstants.EventDescriptionMinLength, ErrorMessage = ErrorConstants.StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        public string Start { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)] 
        public string End { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorConstants.RequireErrorMessage)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
