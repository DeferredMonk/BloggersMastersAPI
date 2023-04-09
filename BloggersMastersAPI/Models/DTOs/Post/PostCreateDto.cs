namespace BloggersMastersAPI.Models.DTOs.Post
{
    public class PostCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool PublicPost { get; set; }
        public int UserId { get; set; }
    }
}
