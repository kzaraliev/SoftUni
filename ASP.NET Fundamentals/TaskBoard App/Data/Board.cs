using System.ComponentModel.DataAnnotations;

namespace TaskBoard_App.Data
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Board.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}