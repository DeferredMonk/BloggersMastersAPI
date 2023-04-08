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

        public async Task<User> Create(User entity)
        {
            var userExists = await _context.Users.Where(u => u.username == entity.username).ToListAsync();
            if (userExists.Any())
            {
                throw new UserAlreadyExistsException(entity.username);
            }
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user != null ? user : throw new UserNotFoundException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
