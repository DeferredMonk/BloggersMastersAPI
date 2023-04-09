using BloggersMastersAPI.Models.Models;

namespace BloggersMastersAPI.Services.Interfaces
{
    public interface IPostService : ICrudOperations<Post, int>
    {
        public Task<ICollection<Post>> GetAllUserPostsByUserId(int id);
    }
}
