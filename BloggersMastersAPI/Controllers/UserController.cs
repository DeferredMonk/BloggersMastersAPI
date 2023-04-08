using System.Net.Mime;
using BloggersMastersAPI.Expections.User;
using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloggersMastersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets all users from the database
        /// </summary>
        /// <returns>A list of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (UsersNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }

        }
        /// <summary>
        /// Gets one users from the database based on ID
        /// </summary>
        /// <returns>A list of users</returns>
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUserById(int id)
        //{
        //    var test = await _context.Users
        //        .Include(x => x.Posts)
        //        .Where(u => u.Id == id)
        //        .SingleOrDefaultAsync();
        //    return Ok(test);
        //}
    }
}
