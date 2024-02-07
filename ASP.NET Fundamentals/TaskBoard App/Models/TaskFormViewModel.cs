﻿using System.ComponentModel.DataAnnotations;
using TaskBoard_App.Data;

namespace TaskBoard_App.Models
{
    public class TaskFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Task.TitleMaxLength)]
        [MinLength(DataConstants.Task.TitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.Task.DescriptionMaxLength)]
        [MinLength(DataConstants.Task.DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public int? BoardId { get; set; }

        [Required]
        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();
    }
}