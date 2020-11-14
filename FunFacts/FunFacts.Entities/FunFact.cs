using FunFacts.Entities.UserEntities;
using System;

namespace FunFacts.Entities
{
    public class FunFact : Base
    {
        public string Description { get; set; }
        public virtual AppUser Author { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
