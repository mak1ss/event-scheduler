﻿using Events.DAL.Interfaces;
using Events.DAL.Interfaces.Repositories;
using Events.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace Events.DAL.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity<int>
    {
        protected readonly EventContext context;
        protected readonly DbSet<TEntity> table;

        public GenericRepository(EventContext context)
        {
            this.context = context;
            table = this.context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await table.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await table.FindAsync(id)
                ?? throw new EntityNotFoundException(
                    GetEntityNotFoundErrorMessage(id));
        }

        public abstract Task<TEntity> GetCompleteEntityAsync(int id);

        public virtual async Task InsertAsync(TEntity entity)
        {
            if(entity is ITrackable) {
                var trackable = (ITrackable)entity;
                trackable.CreatedAt = DateTime.UtcNow;
            }
            await table.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity is ITrackable)
            {
                var trackable = (ITrackable)entity;
                trackable.UpdatedAt = DateTime.UtcNow;
            }
            await Task.Run(() => table.Update(entity));
        }
            
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await Task.Run(() => table.Remove(entity));
        }

        protected static string GetEntityNotFoundErrorMessage(int id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";
    }
}
