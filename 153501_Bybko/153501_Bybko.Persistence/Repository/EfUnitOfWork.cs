using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Domain.Entities;
using _153501_Bybko.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_Bybko.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Artist>> _artistRepository;
        private readonly Lazy<IRepository<Song>> _songRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _artistRepository = new Lazy<IRepository<Artist>>(() =>
                                    new EfRepository<Artist>(context));
            _songRepository = new Lazy<IRepository<Song>>(() =>
                                    new EfRepository<Song>(context));
        }

        IRepository<Artist> IUnitOfWork.ArtistRepository => _artistRepository.Value;

        IRepository<Song> IUnitOfWork.SongRepository => _songRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatabaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
