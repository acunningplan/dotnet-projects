using System.Threading.Tasks;

namespace Burgler.BusinessLogic.MenuLogic
{
    public interface IMenuServices
    {
        Task<Menu> GetMenu();
    }
}