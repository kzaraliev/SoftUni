using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp2.Core.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The {0} field must be between {2} and {1} characters long")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(1500, MinimumLength = 6, ErrorMessage = "The {0} field must be between {2} and {1} characters long")]
        public string Content { get; set; } = string.Empty;
    }
}
