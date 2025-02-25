namespace api.Models
{
    public class Comment
    {
        public int? PostId { get; set; }
        public MediaPost? Post { get; set; } // Navigation property: allows us to navigate from a Comment to the MediaPost it belongs to

        public string? Text { get; set; } = string.Empty;
        public string? Author { get; set; } = string.Empty;
        public DateTime? DatePosted { get; set; } = DateTime.Now;
    }
}