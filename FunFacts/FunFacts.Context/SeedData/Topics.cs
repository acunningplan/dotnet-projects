using FunFacts.Entities;
using FunFacts.Entities.Images;
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
                },
                Pictures = new List<Image>
                {
                    new Image
                    {
                        Url="https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/Novak_Djokovic_Queen%27s_Club_2018.jpg/1200px-Novak_Djokovic_Queen%27s_Club_2018.jpg",
                        IsMain = true
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
                },
                Pictures = new List<Image>
                {
                    new Image
                    {
                        Url="https://www.holland.com/upload_mm/d/0/7/69550_fullimage_fietsen-amsterdam_1360x.jpg",
                        IsMain = true
                    },
                    new Image
                    {
                        Url="https://www.telegraph.co.uk/content/dam/Travel/Destinations/Europe/Netherlands/Amsterdam/amsterdam-dusk-lead-image-guide.jpg"
                    }
                }
            }
        };
    }
}
