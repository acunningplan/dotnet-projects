using FunFacts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunFacts.Context.SeedData
{
    public static class Topics
    {
        public static List<Topic> SampleTopics = new List<Topic>()
        {
            new Topic {
                Name = "Sport",
                Introduction = "Football, tennis, golf, you name it!"
            },
            new Topic {
                Name = "Travel",
                Introduction = "Hot holiday destinations"
            }
        };
    }
}
