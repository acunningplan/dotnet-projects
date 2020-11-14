using FunFacts.Entities.UserEntities;
using System.Collections.Generic;

namespace FunFacts.Entities
{
    public class Topic : Base
    {
        public string Introduction { get; set; }
        public virtual AppUser CreatedBy { get; set; }
        public virtual ICollection<FunFact> FunFacts { get; set; } = new List<FunFact>();
        public virtual ICollection<TopicLabel> Labels { get; set; } = new List<TopicLabel>();
    }
}
