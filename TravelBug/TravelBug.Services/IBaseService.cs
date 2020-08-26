using System;
using System.Threading.Tasks;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
    public interface IBaseService<TEntity, TEntityDto> where TEntity : class, IBase
    {
        Task<TEntity> GetEntity(Guid id, bool tracking = true);
        Task<TEntityDto> CreateAsync(TEntity entity);
        Task<TEntityDto> ReadAsync(Guid id, bool tracking = true);
        Task<TEntityDto> UpdateAsync(Guid id, TEntity updateEntity);
        Task DeleteAsync(Guid id);
    }
}