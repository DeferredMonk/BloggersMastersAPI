namespace BloggersMastersAPI.Expections.Post
{
    public class PostsNotFoundException : Exception
    {
        public PostsNotFoundException() : base("No posts found")
        {

        }
    }
}
