using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Shared;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDto
    {
        [Required]
        [MinLength(GlobalConstants.EmployeeUsernameMin)]
        [MaxLength(GlobalConstants.EmployeeUsernameMax)]
        [RegularExpression(GlobalConstants.EmployeeUsernameRegex)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.EmployeePhoneRegex)]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
