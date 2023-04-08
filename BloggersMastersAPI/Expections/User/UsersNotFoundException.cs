namespace BloggersMastersAPI.Expections.User
{
    public class UsersNotFoundException : Exception
    {
        public UsersNotFoundException() : base("No users found")
        {

        }
    }
}
