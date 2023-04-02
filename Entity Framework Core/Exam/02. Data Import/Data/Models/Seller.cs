using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Shared;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.SellerNameMin)]
        [MaxLength(GlobalConstants.SellerNameMax)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.SellerAddressMin)]
        [MaxLength(GlobalConstants.SellerAddressMax)]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.SellerWebsiteRegex)]
        public string Website { get; set; }

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
