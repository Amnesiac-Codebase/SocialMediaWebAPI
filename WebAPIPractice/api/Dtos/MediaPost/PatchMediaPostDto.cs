using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.MediaPost
{
    public class PatchMediaPostDto
    {
        public string? Title { get; set; } = null;
        public string? Description { get; set; } = null;
        public string? Author { get; set; } = null;
        public DateTime? DatePosted { get; set; } = null;
    }
}