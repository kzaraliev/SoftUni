using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Theatre.Data.Models;
using Theatre.Shared;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportProjectionsDto
    {
        [Required]
        [MinLength(GlobalConstants.TheatreNameMinLength)]
        [MaxLength(GlobalConstants.TheatreNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(GlobalConstants.TheatreDirectorMinLength)]
        [MaxLength(GlobalConstants.TheatreDirectorMaxLength)]
        public string Director { get; set; }

        public TicketsInfo[] Tickets { get; set; }
    }

    public class TicketsInfo
    {
        [Required]
        [Range(typeof(decimal), "1.00", "100.00")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
