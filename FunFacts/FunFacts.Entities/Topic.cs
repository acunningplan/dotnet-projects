using FunFacts.Entities.User;
using FunFacts.Entities.Images;
using System.Collections.Generic;

namespace FunFacts.Entities
{
    public class Topic : Base
    {
        public string Name { get; set; }
        public string Introduction { get; set; }
        public virtual AppUser CreatedBy { get; set; }
        public virtual ICollection<FunFact> FunFacts { get; set; } = new List<FunFact>();
        public virtual ICollection<TopicLabel> Labels { get; set; } = new List<TopicLabel>();
        public virtual ICollection<Image> Pictures { get; set; } = new List<Image>();
    }
}
