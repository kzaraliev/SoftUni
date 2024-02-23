using AdvancedDemo.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AdvancedDemo.Models
{
    public class HomeViewModel : IValidatableObject
    {
        [IsAdult(18, ErrorMessage = "Must be at lest 18 years old")]
        public DateTime BirthDate { get; set; }

        public string? Name { get; set; }

        public string? Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required");
            }

            if (string.IsNullOrEmpty(Country))
            {
                yield return new ValidationResult("Country is required");
            }

            if (Name == "Pesho" && Country != "BG")
            {
                yield return new ValidationResult("If name is Pesho, country must be BG");
            }
        }
    }
}
