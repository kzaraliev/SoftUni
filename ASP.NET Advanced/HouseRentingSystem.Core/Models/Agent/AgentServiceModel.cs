using System.ComponentModel;

namespace HouseRentingSystem.Core.Models.Agent
{
    public class AgentServiceModel
    {
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
