using BloggersMastersAPI.Models.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BloggersMastersAPI.Services.Interfaces
{
    public interface IPostService : ICrudOperations<Post, int>
    {
        /// <summary>
        /// Gets all user posts from the database
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>List of posts</returns>
        public Task<ICollection<Post>> GetAllUserPostsByUserId(int id);
        /// <summary>
        /// Manipulates likes and dislikes
        /// </summary>
        /// <param name="entity">like or dislike entity</param>
        /// <param name="Id">id of resource to patch</param>
        /// <returns>patched resource</returns>
        public Task<Post> UpdateLikes(JsonPatchDocument entity, int Id);
    }
}
