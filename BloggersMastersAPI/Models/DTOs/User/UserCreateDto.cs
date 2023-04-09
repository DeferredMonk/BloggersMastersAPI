namespace BloggersMastersAPI.Models.DTOs.User
{
    /// <summary>
    /// DTO for user creation
    /// </summary>
    public class UserCreateDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
    }
}
