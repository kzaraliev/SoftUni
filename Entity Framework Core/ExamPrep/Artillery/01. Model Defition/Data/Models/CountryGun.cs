using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [Required]
        [ForeignKey("Gun")]
        public int GunId { get; set; }
        public virtual Gun Gun { get; set; }
    }
}
