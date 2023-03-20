using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Footballers.Shared;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamsDto
    {
        [Required]
        [MinLength(GlobalConstants.TeamNameMinLength)]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        [RegularExpression(GlobalConstants.TeamNameRegex)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.TeamNameMinLength)]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        public string Nationality { get; set; }


        [Required]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
