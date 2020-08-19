using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBug.Context;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, IBase
    {
        protected TravelBugContext _travelBugContext;

        protected BaseService([NotNull] TravelBugContext crudApiDbContext)
        {
            _travelBugContext = crudApiDbContext;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _travelBugContext.Set<TEntity>().AddAsync(entity);
            await _travelBugContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> ReadAsync(int id, bool tracking = true)
        {
            var query = _travelBugContext.Set<TEntity>().AsQueryable();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(entity => entity.Id == id && !entity.Deleted.HasValue);
        }

        public virtual async Task<TEntity> UpdateAsync(int id, TEntity updateEntity)
        {
            // Check that the record exists.
            var entity = await ReadAsync(id);

            if (entity == null)
            {
                throw new Exception("Unable to find record with id '" + id + "'.");
            }

            // Update changes if any of the properties have been modified.
            _travelBugContext.Entry(entity).CurrentValues.SetValues(updateEntity);
            _travelBugContext.Entry(entity).State = EntityState.Modified;

            if (_travelBugContext.Entry(entity).Properties.Any(property => property.IsModified))
            {
                await _travelBugContext.SaveChangesAsync();
            }
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            // Check that the record exists.
            var entity = await ReadAsync(id);

            if (entity == null)
            {
                throw new Exception("Unable to find record with id '" + id + "'.");
            }

            // Set the deleted flag.
            entity.Deleted = DateTimeOffset.Now;
            _travelBugContext.Entry(entity).State = EntityState.Modified;

            // Save changes to the Db Context.
            await _travelBugContext.SaveChangesAsync();
        }
    }
}
