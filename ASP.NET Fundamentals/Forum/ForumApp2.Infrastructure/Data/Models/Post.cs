using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Data.Models
{

    [Comment("Posts table")]
    public class Post
    {
        [Key]
        [Comment("Post identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("Post title")]
        public required string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        [Comment("Post content")]
        public required string Content { get; set; }
    }
}
