namespace BloggersMastersAPI.Models.DTOs.User
{
    /// <summary>
    /// Simble user dto for getting user data
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
    }
}
