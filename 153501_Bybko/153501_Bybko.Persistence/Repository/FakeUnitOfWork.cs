using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Domain.Entities;

namespace _153501_Bybko.Persistence.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public IRepository<Artist> ArtistRepository => new FakeArtistRepository();

        public IRepository<Song> SongRepository => new FakeSongRepository();

        public Task CreateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
