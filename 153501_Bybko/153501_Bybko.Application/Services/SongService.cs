using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Domain.Entities;

namespace _153501_Bybko.Application.Services
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Song> _songRepository;

        public SongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _songRepository = _unitOfWork.SongRepository;
        }

        public async Task AddAsync(Song item)
        {
            await _songRepository.AddAsync(item);
            await _unitOfWork.SaveAllAsync();
        }

        public Task<Song> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Song>> GetAllAsync()
        {
            return _songRepository.ListAllAsync();
        }

        public Task<IReadOnlyList<Song>> GetArtistSongs(int id)
        {
            var songs = _songRepository.ListAsync(song => song.ArtistId == id);
            return songs;
        }

        public Task<Song> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Song item)
        {
            await _songRepository.UpdateAsync(item);
            await _unitOfWork.SaveAllAsync();
        }
    }
}
