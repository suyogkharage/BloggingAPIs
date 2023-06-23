namespace BloggingAPI.DTOs
{
    public class BlogPostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
