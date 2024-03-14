using HouseRentingSystem.Core.Enumaeration;
using System.ComponentModel;

namespace HouseRentingSystem.Core.Models.House
{
    public class AllHousesQueryModel
    {
        public int HousesPerPage { get; } = 3;

        public string Category { get; init; } = null!;

        [DisplayName("Search by text")]
        public string SearchTerm { get; set; } = null!;

        public HouseSorting Sorting { get; init; }

        public int CurrentPage { get; set; } = 1;

        public int TotalHousesCount { get; set; }
        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<HouseServiceModel> Houses { get; set; } = new List<HouseServiceModel>();
    }
}
