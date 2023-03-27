using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Artillery.Shared;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Range(GlobalConstants.ShellWeightMin, GlobalConstants.ShellWeightMax)]
        public double ShellWeight { get; set; }

        [Required]
        [MinLength(GlobalConstants.ShellCaliberMin)]
        [MaxLength(GlobalConstants.ShellCaliberMax)]
        public string Caliber { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
