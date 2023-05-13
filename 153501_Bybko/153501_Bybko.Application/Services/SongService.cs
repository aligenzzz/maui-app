using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Domain.Entities;

namespace _153501_Bybko.Application.Services
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Song> AddAsync(Song item)
        {
            throw new NotImplementedException();
        }

        public Task<Song> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Song>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Song>> GetArtistSongs(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Song> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Song> UpdateAsync(Song item)
        {
            throw new NotImplementedException();
        }
    }
}
