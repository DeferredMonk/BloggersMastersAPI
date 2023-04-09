namespace BloggersMastersAPI.Models.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool PublicPost { get; set; }
        public int Agrees { get; set; }
        public int Disagrees { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
