using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime? DatePosted { get; set; } = DateTime.Now;
        public int? PostId { get; set; } // Foreign key: allows us to link a Comment to a MediaPost
    }
}