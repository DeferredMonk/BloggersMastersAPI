using AutoMapper;
using BloggersMastersAPI.Expections.Post;
using BloggersMastersAPI.Models;
using BloggersMastersAPI.Models.DTOs.Post;
using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BloggersMastersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly BloggersMastersContext _context;
        private readonly IPostService _PostService;
        private readonly IMapper _mapper;

        public PostController(BloggersMastersContext context, IPostService postService, IMapper mapper)
        {
            _context = context;
            _PostService = postService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all public posts
        /// </summary>
        /// <returns>List of posts</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
        {
            try
            {
                return Ok(_mapper.Map<List<PostDto>>(await _PostService.GetAll()));
            }
            catch (PostsNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }

        /// <summary>
        /// Gets all posts of a user by user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Found posts</returns>
        [Authorize]
        [HttpGet("user/{id}")]
        public async Task<ActionResult<PostDto>> GetPostByUserId(int id)
        {
            try
            {
                return Ok(_mapper.Map<List<PostDto>>(await _PostService.GetAllUserPostsByUserId(id)));
            }
            catch (PostsNotFoundException e)
            {
                return NotFound(new ProblemDetails { Detail = e.Message });
            }
        }

        /// <summary>
        /// Gets a post by id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Found post</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            try
            {
                return _mapper.Map<PostDto>(await _PostService.GetById(id));
            }
            catch (PostsNotFoundException e)
            {
                return NotFound(new ProblemDetails { Detail = e.Message });
            }
        }
        /// <summary>
        /// Updates a resource with given data
        /// </summary>
        /// <param name="id">Id of the resource</param>
        /// <param name="post">what do add</param>
        /// <param name="target">targeted part of object</param>
        /// <returns>Updated resource</returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<PostModifyDto>> PatchPost(int id, JsonPatchDocument post, string target)
        {
            try
            {
                if (target == "likes")
                {
                    return Ok(_mapper.Map<PostModifyDto>(await _PostService.UpdateLikes(post, id)));
                }
                return Ok(_mapper.Map<PostModifyDto>(await _PostService.Update(post, id)));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="post">New post</param>
        /// <returns>Created new post</returns>
        [HttpPost]
        public async Task<ActionResult<PostCreateDto>> PostPost(PostCreateDto post)
        {
            try
            {
                var newPost = await _PostService.Create(_mapper.Map<Post>(post));
                return Created("GetPost", _mapper.Map<PostDto>(newPost));
            }
            catch (Exception e)
            {
                return BadRequest(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
