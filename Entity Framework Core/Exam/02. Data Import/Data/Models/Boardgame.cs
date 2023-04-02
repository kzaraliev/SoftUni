using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Data.Models.Enums;
using Boardgames.Shared;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.BoardgameNameMin)]
        [MaxLength(GlobalConstants.BoardgameNameMax)]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.BoardgameRatingMin, GlobalConstants.BoardgameRatingMax)]
        public double Rating { get; set; }

        [Required]
        [Range(GlobalConstants.BoardgameYearPublishedMin, GlobalConstants.BoardgameYearPublishedMax)]
        public int YearPublished { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public string Mechanics  { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        public virtual Creator Creator { get; set; }

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
