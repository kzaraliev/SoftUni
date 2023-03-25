using System.ComponentModel.DataAnnotations;
using Theatre.Shared;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientsDto
    {
        [Required]
        [MinLength(GlobalConstants.ClientNameMin)]
        [MaxLength(GlobalConstants.ClientNameMax)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientNationalityMin)]
        [MaxLength(GlobalConstants.ClientNationalityMax)]
        public string Nationality { get; set; }

        [Required]
        public string Type { get; set; }

        public int[] Trucks { get; set; }
    }
}
