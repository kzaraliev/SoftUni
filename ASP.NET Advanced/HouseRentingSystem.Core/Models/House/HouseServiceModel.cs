using HouseRentingSystem.Core.Constants;
using HouseRentingSystem.Infrastucture.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [StringLength(DataConstants.TitleMaxLength, MinimumLength = DataConstants.TitleMinLength, ErrorMessage = MessageConstants.LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [StringLength(DataConstants.AddressMaxLength, MinimumLength = DataConstants.AddressMinLength, ErrorMessage = MessageConstants.LengthMessage)]
        public string Address { get; set; } = string.Empty;

        [DisplayName("Image URL")]
        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        [DisplayName("Price per month")]
        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [Range(typeof(decimal), DataConstants.RentingPriceMin, DataConstants.RentingPriceMax, ConvertValueInInvariantCulture = true, ErrorMessage = "Price per month must be a positive number and less than {2} lv.")]
        public decimal PricePerMonth { get; set; }

        [DisplayName("Is Rented")]
        public bool IsRented { get; set; }
    }
}