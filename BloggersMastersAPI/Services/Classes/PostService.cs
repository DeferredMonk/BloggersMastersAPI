using BloggersMastersAPI.Models;
using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;

namespace BloggersMastersAPI.Services.Classes
{
    public class PostService : IPostService
    {
        private readonly BloggersMastersContext _context;
        public PostService(BloggersMastersContext context)
        {
            _context = context;
        }
        public async Task<Post> Create(Post entity)
        {
            await _context.Posts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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
