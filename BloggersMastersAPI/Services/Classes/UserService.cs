using BloggersMastersAPI.Expections.User;
using BloggersMastersAPI.Models;
using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloggersMastersAPI.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly BloggersMastersContext _context;
        public UserService(BloggersMastersContext context)
        {
            _context = context;
        }

        public Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.Include(u => u.Posts).ToListAsync();

            return users.Count > 0 ? users : throw new UsersNotFoundException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
