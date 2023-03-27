using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Artillery.Shared;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.ManufacturerNameMin)]
        [MaxLength(GlobalConstants.ManufacturerNameMax)]
        //UNIQUE
        public string ManufacturerName { get; set; }

        [Required]
        [MinLength(GlobalConstants.ManufacturerFoundedMin)]
        [MaxLength(GlobalConstants.ManufacturerFoundedMax)]
        public string Founded { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
