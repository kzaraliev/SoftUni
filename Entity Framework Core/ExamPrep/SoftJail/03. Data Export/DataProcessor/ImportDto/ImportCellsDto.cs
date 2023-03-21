using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Footballers.Shared;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportCellsDto
    {
        [Required]
        [Range(GlobalConstants.CellMinLength, GlobalConstants.CellMaxNumber)]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
    }
}
