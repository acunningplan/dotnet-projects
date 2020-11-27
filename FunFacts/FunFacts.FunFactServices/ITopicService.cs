using FunFacts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunFacts.FunFactServices
{
    public interface ITopicService
    {
        Task AddTopic();
        Task<List<Topic>> GetTopics();
    }
}