using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Domain.Entities;
using _153501_Bybko.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace _153501_Bybko.Persistence.Repository
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (_entities.Contains(entity))
                _entities.Remove(entity);

            return Task.CompletedTask;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, 
                                           CancellationToken cancellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            try
            {
                var result = await query.FirstAsync(filter, cancellationToken);

                return result;
            }
            catch (InvalidOperationException)
            {
                return default;
            }
        }

        public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, 
                                    params Expression<Func<T, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, 
                                                      CancellationToken cancellationToken = default,
                                                      params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties != null && includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
