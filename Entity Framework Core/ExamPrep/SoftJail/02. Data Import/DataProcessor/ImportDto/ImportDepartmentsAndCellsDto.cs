using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Footballers.Shared;
using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentsAndCellsDto
    {
        [JsonProperty("Name")]
        [MaxLength(GlobalConstants.DepartmentNameMaxLength)]
        [MinLength(GlobalConstants.DepartmentNameMinLength)]
        [Required]
        public string Name { get; set; }
        
        public ImportCellsDto[] Cells { get; set; }
    }
}
