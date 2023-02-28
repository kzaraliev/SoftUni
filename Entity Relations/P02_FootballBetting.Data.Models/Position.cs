using System.ComponentModel.DataAnnotations;
using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models;
public class Position
{
    public Position()
    {
        Players = new HashSet<Player>();
    }

    [Key]
    public int PositionId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PositionNameMaxLength)]
    public string Name { get; set; }

    public virtual ICollection<Player> Players { get; set; }
}