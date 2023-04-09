using AutoMapper;
using BloggersMastersAPI.Expections.User;
using BloggersMastersAPI.Models.DTOs.User;
using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloggersMastersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all users from the database
        /// </summary>
        /// <returns>A list of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<UserDto>>(await _userService.GetAll()));
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
        /// <returns>the searched user</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            try
            {
                return Ok(_mapper.Map<UserDto>(await _userService.GetById(id)));
            }
            catch (UserNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }
        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="user">New user to create</param>
        /// <returns>Created user</returns>
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateNewUser(UserCreateDto user)
        {
            try
            {
                var newUser = _mapper.Map<User>(user);
                await _userService.Create(newUser);
                return Created("User creation", user);
            }
            catch (UserAlreadyExistsException e)
            {
                return BadRequest(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }
    }
}
