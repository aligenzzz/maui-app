using _153501_Bybko.Domain.Entities;

namespace _153501_Bybko.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Artist> ArtistRepository { get; }
        IRepository<Song> SongRepository { get; }
        public Task RemoveDatabaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}
