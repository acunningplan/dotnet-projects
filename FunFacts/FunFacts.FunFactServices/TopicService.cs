using FunFacts.Context;
using FunFacts.Entities;
using System.Threading.Tasks;

namespace FunFacts.FunFactServices
{
    public class TopicService : ITopicService
    {
        private readonly FunFactsContext _context;

        public TopicService(FunFactsContext context)
        {
            _context = context;
        }
        public async Task AddTopic()
        {
            _context.Topics.Add(new Topic());
            await _context.SaveChangesAsync();
        }
    }
}
