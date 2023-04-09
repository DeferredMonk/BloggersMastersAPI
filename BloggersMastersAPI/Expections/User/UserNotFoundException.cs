namespace BloggersMastersAPI.Expections.User
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found")
        {

        }
    }
}
