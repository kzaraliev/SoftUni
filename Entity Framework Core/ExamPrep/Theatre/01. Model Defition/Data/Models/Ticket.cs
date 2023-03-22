using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        public Ticket()
        {
            
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0.00, 100.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        [Required]
        [ForeignKey("Play")]
        public int PlayId { get; set; }

        public virtual Play Play { get; set; }

        [Required]
        [ForeignKey("Theatre")]
        public int TheatreId { get; set; }

        public Theatre Theatre { get; set; }
    }
}
