using BloggersMastersAPI.Expections.Post;
using BloggersMastersAPI.Models;
using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Post>> GetAll()
        {
            var Posts = await _context.Posts
                .Include(p => p.User)
                .ToListAsync();
            if (!Posts.Any())
            {
                throw new PostsNotFoundException();
            }
            return Posts;
        }

        public async Task<ICollection<Post>> GetAllUserPostsByUserId(int id)
        {
            var Posts = await _context.Posts
                .Include(p => p.User)
                .Where(p => p.UserId == id)
                .ToListAsync();
            if (!Posts.Any())
            {
                throw new PostsNotFoundException();
            }
            return Posts;
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
