namespace BloggersMastersAPI.Services.Interfaces
{
    public interface ICrudOperations<T, Id>
    {
        /// <summary>
        /// Gets all resources from a table
        /// </summary>
        /// <returns>IEnumerable of resources</returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Gets a resource by the sources Id
        /// </summary>
        /// <param name="id">Id of the resource</param>
        /// <returns>The searched resource</returns>
        Task<T> GetById(Id id);
        /// <summary>
        /// Creates a new resource
        /// </summary>
        /// <param name="entity">Resource to create</param>
        /// <returns>New resource</returns>
        Task<T> Create(T entity);
        /// <summary>
        /// Updates current resource
        /// </summary>
        /// <param name="entity">Resource with updated values</param>
        /// <returns></returns>
        Task<T> Update(T entity);
        /// <summary>
        /// Deletes a resource
        /// </summary>
        /// <param name="id">Id of the resource to delete</param>
        /// <returns>Nothing</returns>
        Task DeleteById(Id id);
    }
}
