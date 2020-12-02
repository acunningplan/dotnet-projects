using FunFacts.Entities;
using System.Threading.Tasks;

namespace FunFacts.FunFactServices
{
    public interface IFunFactService
    {
        Task AddFunFact(FunFact funFact);
    }
}