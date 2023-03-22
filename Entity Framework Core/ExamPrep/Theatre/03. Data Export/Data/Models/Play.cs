using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;
using Theatre.Shared;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Casts = new HashSet<Cast>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayScreenWriterMaxLength)]
        public string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
