﻿using _153501_Bybko.Domain.Entities;

namespace _153501_Bybko.Application.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> DeleteAsync(int id);
    }
}
