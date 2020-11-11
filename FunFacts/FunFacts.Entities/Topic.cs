using FunFacts.Entities.UserEntities;
using System.Collections.Generic;

namespace FunFacts.Entities
{
    public class Topic
    {
        public string Introduction { get; set; }
        public virtual AppUser CreatedBy { get; set; }
        public virtual ICollection<FunFact> FunFacts { get; set; } = new List<FunFact>();
        public virtual ICollection<Label> Labels { get; set; } = new List<Label>();
    }
}
