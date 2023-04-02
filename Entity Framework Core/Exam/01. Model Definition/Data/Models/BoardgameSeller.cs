using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [Required]
        [ForeignKey("Boardgame")]
        public int BoardgameId  { get; set; }
        public virtual Boardgame Boardgame { get; set; }

        [Required]
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public virtual Seller Seller { get;}
    }
}
