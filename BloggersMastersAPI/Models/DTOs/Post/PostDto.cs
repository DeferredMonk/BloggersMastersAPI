namespace BloggersMastersAPI.Models.DTOs.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool PublicPost { get; set; }
    }
}
