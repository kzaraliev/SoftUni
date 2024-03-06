using HouseRentingSystem.Core.Constants;
using HouseRentingSystem.Infrastucture.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required(ErrorMessage = MessageConstants.RequiredMessage)]
        [StringLength(DataConstants.PhoneNumberMaxLength, MinimumLength = DataConstants.PhoneNumberMinLength)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
