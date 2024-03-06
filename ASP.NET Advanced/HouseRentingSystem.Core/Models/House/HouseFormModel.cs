using HouseRentingSystem.Core.Constants;
using HouseRentingSystem.Infrastucture.Constants;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseFormModel
    {
        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [StringLength(DataConstants.TitleMaxLength, MinimumLength = DataConstants.TitleMinLength, ErrorMessage = MessageConstants.LengthMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [StringLength(DataConstants.AddressMaxLength, MinimumLength = DataConstants.AddressMinLength, ErrorMessage = MessageConstants.LengthMessage)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [StringLength(DataConstants.DescriptionMaxLength, MinimumLength = DataConstants.DescriptionMinLength, ErrorMessage = MessageConstants.LengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [Range(typeof(decimal), DataConstants.RentingPriceMin, DataConstants.RentingPriceMax,ConvertValueInInvariantCulture = true, ErrorMessage = "Price per month must be a positive number and less than {2} lv.")]
        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } = new List<HouseCategoryServiceModel>();
    }
}
