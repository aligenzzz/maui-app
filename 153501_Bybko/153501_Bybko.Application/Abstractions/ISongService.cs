using _153501_Bybko.Domain.Entities;

namespace _153501_Bybko.Application.Abstractions
{
    public interface ISongService : IBaseService<Song>
    {
        Task<IReadOnlyList<Song>> GetArtistSongs(int id);
    }
}
