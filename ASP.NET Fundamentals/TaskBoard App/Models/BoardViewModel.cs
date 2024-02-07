using System.ComponentModel.DataAnnotations;
using TaskBoard_App.Data;

namespace TaskBoard_App.Models
{
    public class BoardViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Board.NameMaxLength, MinimumLength = DataConstants.Board.NameMinLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
