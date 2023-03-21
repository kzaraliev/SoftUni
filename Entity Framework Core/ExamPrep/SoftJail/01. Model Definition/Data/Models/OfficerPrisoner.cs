using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }

        [ForeignKey("Officer")]
        public int OfficerId { get; set; }

        public Officer Officer { get; set; }
    }
}
