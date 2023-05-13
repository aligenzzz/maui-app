using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _153501_Bybko.Persistence.Repository
{
    public class FakeArtistRepository : IRepository<Artist>
    {
        List<Artist> _list = new List<Artist>();
        public FakeArtistRepository()
        {
            Random rand = new Random();
            int k = 1;
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 10; j++)
                    _list.Add(new Artist()
                    {
                        Id = k,
                        Name = $"Artist {k++}",
                    });
        }

        public async Task<IReadOnlyList<Artist>> ListAsync(Expression<Func<Artist, bool>> filter, 
                                                            CancellationToken cancellationToken = default, 
                                                            params Expression<Func<Artist, object>>[]? includesProperties)
        {
            var data = _list.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task AddAsync(Artist entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Artist entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> FirstOrDefaultAsync(Expression<Func<Artist, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Artist, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Artist>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return _list;
        }

        public Task UpdateAsync(Artist entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }


    public class FakeSongRepository : IRepository<Song>
    {
        List<Song> _list = new List<Song>();
        public FakeSongRepository()
        {
            Random rand = new Random();
            int k = 1;
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 10; j++)
                    _list.Add(new Song()
                    {
                        Id = k,
                        Name = $"Song {k++}",
                        Artist = k,
                        Top = k
                    });
        }

        public async Task<IReadOnlyList<Song>> ListAsync(Expression<Func<Song, bool>> filter,
                                                         CancellationToken cancellationToken = default,
                                                         params Expression<Func<Song, object>>[]? includesProperties)
        {
            var data = _list.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task AddAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Song> FirstOrDefaultAsync(Expression<Func<Song, bool>> filter, 
                                              CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Song> GetByIdAsync(int id, CancellationToken cancellationToken = default, 
                                       params Expression<Func<Song, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Song>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return _list;
        }

        public Task UpdateAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
