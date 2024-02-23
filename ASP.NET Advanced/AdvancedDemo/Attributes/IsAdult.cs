using System.ComponentModel.DataAnnotations;

namespace AdvancedDemo.Attributes
{
    public class IsAdult : ValidationAttribute
    {
        private readonly DateTime minimumAge = DateTime.Today.AddYears(-18);
        private readonly int adultAge = 18;

        public IsAdult(int age) {
            adultAge = age;
            minimumAge = DateTime.Today.AddYears(age * - 1);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && (DateTime)value <= minimumAge)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
