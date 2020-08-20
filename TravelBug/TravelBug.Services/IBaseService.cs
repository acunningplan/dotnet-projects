using System;
using System.Threading.Tasks;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
    public interface IBaseService<TEntity> where TEntity : class, IBase
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(Guid id, bool tracking = true);
        Task<TEntity> UpdateAsync(Guid id, TEntity updateEntity);
        Task DeleteAsync(Guid id);
    }
}