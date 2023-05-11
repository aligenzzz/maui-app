using System.Linq.Expressions;
using _153501_Bybko.Domain.Entities;

namespace _153501_Bybko.Domain.Abstractions
{
    public interface IRepository<T> where T: Entity
    {
        /// <summary>Searching for an entity by id</summary> 
        /// <param name="id">Entity Id</param> 
        /// <param name="cancellationToken"></param> 
        /// <param name="includesProperties">Delegates for enabling navigation properties</param>
        /// <returns></returns> 
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default,
                             params Expression<Func<T, object>>[]? includesProperties);

 
        /// <summary>Getting the entire list of entities</summary> 
        /// <param name="cancellationToken"></param> 
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);


        /// <summary>Getting a filtered list</summary> 
        /// <param name="filter">Conditional delegate for selection</param> 
        /// <param name="cancellationToken"></param>    
        /// <param name="includesProperties">Delegates for enabling navigation properties</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter,
                                         CancellationToken cancellationToken = default,
                                         params Expression<Func<T, object>>[]? includesProperties);


        /// <summary>Adding a new entity</summary> 
        /// <param name="entity"></param> 
        /// <param name="cancellationToken"></param> 
        /// <returns></returns>
        Task AddAsync(T entity, CancellationToken cancellationToken = default);


        /// <summary>Changing an entity</summary> 
        /// <param name="entity">An entity with modified content</param> 
        /// <param name="cancellationToken"></param> 
        /// <returns></returns> 
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);


        /// <summary>Deleting an entity</summary> 
        /// <param name="entity">The entity to be deleted</param> 
        /// <param name="cancellationToken"></param> 
        /// <returns></returns>
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);


        /// <summary>
        /// Search for the first entity satisfying the selection condition.
        /// If the entity is not found, the default value will be returned
        /// </summary> 
        /// <param name="filter">Conditional delegate for selection</param> 
        /// <param name="cancellationToken"></param> 
        /// <returns></returns>
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, 
                                    CancellationToken cancellationToken = default);
    }
}
