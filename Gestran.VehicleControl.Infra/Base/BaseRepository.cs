﻿using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Base
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : BaseEntity
    {
        public readonly ExcContext _context;

        protected BaseRepository(ExcContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public Task<List<TEntity>> GetAsync()
        {
            return _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>().AsNoTracking().AsQueryable();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity param)
        {
            CreateId(param);

            var data = _context.Set<TEntity>().Add(param);
            var result = await _context.SaveChangesAsync();
            return data.Entity;
        }

        public virtual async Task<TEntity> CreateOrUpdateAsync(TEntity entity)
        {
            if (entity.Id != Guid.Empty)
            {
                _context.Entry<TEntity>(entity).State = EntityState.Detached;
                _context.Set<TEntity>().Update(entity);
                var data = _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return data.Entity;
            }
            else
            {
                CreateId(entity);
                var data = _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return data.Entity;
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var local = _context.Set<TEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            if (local != null)
                _context.Entry<TEntity>(local).State = EntityState.Detached;

            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            var result = _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }        

        public virtual async Task DeleteAsync(TEntity param)
        {
            _context.Entry<TEntity>(param).State = EntityState.Detached;
            _context.Set<TEntity>().Remove(param);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            await DeleteAsync(entity);
        }

        private void CreateId(TEntity param)
        {
            if (param.Id == Guid.Empty)
                param.SetId(Guid.NewGuid());
        }
    }
}
