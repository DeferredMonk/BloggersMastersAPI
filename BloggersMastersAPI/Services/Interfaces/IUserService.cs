using BloggersMastersAPI.Models.Models;

namespace BloggersMastersAPI.Services.Interfaces
{
    public interface IUserService : ICrudOperations<User, int>
    {
        Task<User> GetByUsername(string username);
    }
}
