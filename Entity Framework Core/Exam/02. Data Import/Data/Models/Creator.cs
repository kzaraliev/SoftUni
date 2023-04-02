using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Shared;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            Boardgames = new HashSet<Boardgame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CreatorFirstNameMin)]
        [MaxLength(GlobalConstants.CreatorFirstNameMax)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstants.CreatorLastNameMin)]
        [MaxLength(GlobalConstants.CreatorLastNameMax)]
        public string LastName { get; set; }

        public virtual ICollection<Boardgame> Boardgames { get; set; }
    }
}
