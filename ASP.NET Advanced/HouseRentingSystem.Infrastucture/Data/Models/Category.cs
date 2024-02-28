using HouseRentingSystem.Infrastucture.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Infrastucture.Data.Models
{
    [Comment("House category")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.NameLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<House> Houses { get; set; } = new List<House>();
    }
}
