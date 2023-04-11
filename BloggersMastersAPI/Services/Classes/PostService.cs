using BloggersMastersAPI.Expections.Post;
using BloggersMastersAPI.Models;
using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
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
            var posts = await _context.Posts
                .Include(p => p.User)
                .Where(p => p.PublicPost)
                .ToListAsync();
            if (!posts.Any())
            {
                throw new PostsNotFoundException();
            }
            return posts;
        }

        public async Task<ICollection<Post>> GetAllUserPostsByUserId(int id)
        {
            var posts = await _context.Posts
                .Include(p => p.User)
                .Where(p => p.UserId == id)
                .ToListAsync();
            if (!posts.Any())
            {
                throw new PostsNotFoundException();
            }
            return posts;
        }

        public async Task<Post> GetById(int id)
        {
            var post = await _context.Posts
                .Include(p => p.User)
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();

            if (post == null)
            {
                throw new PostsNotFoundException();
            }

            return post;
        }

        public async Task<Post> Update(JsonPatchDocument entity, int Id)
        {
            var postToUpdate = await GetById(Id);
            entity.ApplyTo(postToUpdate);
            await _context.SaveChangesAsync();

            return postToUpdate;
        }
    }
}
