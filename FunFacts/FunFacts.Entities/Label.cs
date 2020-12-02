using System;
using System.Collections.Generic;
using System.Text;

namespace FunFacts.Entities
{
    public class Label : Base
    {
        public string Name { get; set; }
        public virtual ICollection<TopicLabel> Topics { get; set; }
    }
}
