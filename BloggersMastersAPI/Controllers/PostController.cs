using AutoMapper;
using BloggersMastersAPI.Expections.Post;
using BloggersMastersAPI.Models;
using BloggersMastersAPI.Models.DTOs.Post;
using BloggersMastersAPI.Models.Models;
using BloggersMastersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        /// Gets all posts or the posts of a user
        /// </summary>
        /// <param name="userId">Id of the wanted user posts</param>
        /// <returns>List of posts</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts(int userId)
        {
            try
            {
                if (userId != 0)
                {
                    return Ok(_mapper.Map<List<PostDto>>(await _PostService.GetAllUserPostsByUserId(userId)));
                }
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

        // PUT: api/Post/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PostCreateDto>> PostPost(PostCreateDto post)
        {
            try
            {
                var newPost = await _PostService.Create(_mapper.Map<Post>(post));
                return Created("GetPost", newPost);
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

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
