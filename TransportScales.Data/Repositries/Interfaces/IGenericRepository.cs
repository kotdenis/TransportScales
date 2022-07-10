﻿using TransportScales.Data.Entities;

namespace TransportScales.Data.Repositries.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
        Task<TEntity> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<TEntity>> SoftDeleteAsync<T>(int id, CancellationToken ct) where T : BaseEntity;
        Task<IEnumerable<TEntity>> HardDeleteAsync(int id, CancellationToken ct);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);
        Task<IEnumerable<TEntity>> CreateAsync(TEntity entity, CancellationToken ct);

    }
}
