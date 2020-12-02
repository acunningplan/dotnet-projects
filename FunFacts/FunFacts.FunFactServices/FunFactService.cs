using FunFacts.Context;
using FunFacts.Entities;
using System.Threading.Tasks;

namespace FunFacts.FunFactServices
{
    public class FunFactService : IFunFactService
    {
        private readonly FunFactsContext _context;

        public FunFactService(FunFactsContext context)
        {
            _context = context;
        }
        public async Task AddFunFact(FunFact funFact)
        {
            _context.FunFacts.Add(new FunFact());
            await _context.SaveChangesAsync();
        }
    }
}
