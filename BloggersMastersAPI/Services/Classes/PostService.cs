using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;

namespace BloggersMastersAPI.Services.Classes
{
    public class PostService : IPostService
    {
        public Task<Post> Create(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
