using AutoMapper;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TravelBug.Context;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
  public abstract class BaseService<TEntity, TEntityDto> : IBaseService<TEntity, TEntityDto> where TEntity : class, IBase
  {
    protected TravelBugContext _travelBugContext;
    protected IMapper _mapper;

    protected BaseService([NotNull] TravelBugContext crudApiDbContext, IMapper mapper)
    {
      _travelBugContext = crudApiDbContext;
      _mapper = mapper;
    }

    public async Task<TEntity> GetEntity(Guid id, bool tracking = true)
    {
      var query = _travelBugContext.Set<TEntity>().AsQueryable();

      if (!tracking) query = query.AsNoTracking();

      return await query.FirstOrDefaultAsync(entity => entity.Id == id && !entity.Deleted.HasValue)
           ?? throw new Exception("Unable to find record with id '" + id + "'.");
    }

    public virtual async Task<TEntityDto> CreateAsync(TEntity entity)
    {
      await _travelBugContext.Set<TEntity>().AddAsync(entity);
      await _travelBugContext.SaveChangesAsync();

      return _mapper.Map<TEntity, TEntityDto>(entity);
    }

    public virtual async Task<TEntityDto> ReadAsync(Guid id, bool tracking = true)
    {
      var entity = await GetEntity(id, tracking);
      return _mapper.Map<TEntity, TEntityDto>(entity);
    }

    public virtual async Task<TEntityDto> UpdateAsync(Guid id, TEntity updateEntity)
    {
      var entity = await GetEntity(id);

      // Update changes if any of the properties have been modified.
      _travelBugContext.Entry(entity).CurrentValues.SetValues(updateEntity);
      _travelBugContext.Entry(entity).State = EntityState.Modified;

      if (_travelBugContext.Entry(entity).Properties.Any(property => property.IsModified))
      {
        await _travelBugContext.SaveChangesAsync();
      }
      return _mapper.Map<TEntity, TEntityDto>(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
      var entity = await GetEntity(id);

      // Set the deleted flag.
      entity.Deleted = DateTimeOffset.Now;
      _travelBugContext.Entry(entity).State = EntityState.Modified;

      // Save changes to the Db Context.
      await _travelBugContext.SaveChangesAsync();
    }
  }
}
