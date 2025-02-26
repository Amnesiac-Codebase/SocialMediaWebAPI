using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;

namespace api.Dtos.MediaPost
{
    public class MediaPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime? DatePosted { get; set; } = DateTime.Now;
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}