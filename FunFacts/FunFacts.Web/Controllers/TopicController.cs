using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunFacts.Entities;
using FunFacts.FunFactServices;
using Microsoft.AspNetCore.Mvc;

namespace FunFacts.Web.Controllers
{
    [Route("api/topic")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<List<Topic>> GetTopics()
        {
            return await _topicService.GetTopics();
        }

        [HttpPost]
        public async Task AddTopic()
        {
            await _topicService.AddTopic();
        }
    }
}
