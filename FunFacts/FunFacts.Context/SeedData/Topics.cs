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
                Name = "Novak Djokovic",
                Introduction = "One of the celebrated tennis players in history.",
                FunFacts = new List<FunFact>
                {
                    new FunFact
                    {
                        Description = "He was born in 1987 in Belgrade, Serbia."
                    },
                    new FunFact
                    {
                        Description = "As of Nov, 2020 he has won 17 Grand Slam titles."
                    }
                }
            },
            new Topic {
                Name = "Amsterdam",
                Introduction = "Bicycles and coffee shops dominate the capital of the Netherlands.",
                FunFacts = new List<FunFact>
                {
                    new FunFact
                    {
                        Description = "Amsterdam is the birthplace of influential painter Vincent van Gogh."
                    },
                    new FunFact
                    {
                        Description = "It is nicknamed the bike capital of Europe."
                    }
                }
            }
        };
    }
}
