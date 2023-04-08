namespace BloggersMastersAPI.Expections.User
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string username) : base($"There already exists a user with '{username}' as their username")
        {

        }
    }
}
