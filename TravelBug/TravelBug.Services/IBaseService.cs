using System.Threading.Tasks;
using TravelBug.Entities;

namespace TravelBug.CrudServices
{
    public interface IBaseService<TEntity> where TEntity : class, IBase
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(int id, bool tracking = true);
        Task<TEntity> UpdateAsync(int id, TEntity updateEntity);
        Task DeleteAsync(int id);
    }
}