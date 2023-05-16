using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Domain.Entities;
using System.Collections.Generic;

namespace _153501_Bybko.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Artist> _artistRepository;

        public ArtistService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
            _artistRepository = _unitOfWork.ArtistRepository;
        }

        public Task<Artist> AddAsync(Artist item)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Artist>> GetAllAsync()
        {
            var artists = _artistRepository.ListAllAsync();
            return artists;
        }

        public Task<Artist> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Artist item)
        {
            throw new NotImplementedException();
        }
    }
}
