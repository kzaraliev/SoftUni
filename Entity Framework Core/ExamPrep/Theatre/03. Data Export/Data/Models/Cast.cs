using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Theatre.Shared;

namespace Theatre.Data.Models
{
    public class Cast
    {
        public Cast()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CastFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CastRegex)]
        public string PhoneNumber   { get; set; }

        [Required]
        [ForeignKey("Play")]
        public int PlayId { get; set; }

        public virtual Play Play { get; set; }
    }
}
