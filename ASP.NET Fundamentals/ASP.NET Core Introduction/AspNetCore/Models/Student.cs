using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(59, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}