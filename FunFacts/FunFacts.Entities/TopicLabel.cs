using System;
using System.Collections.Generic;
using System.Text;

namespace FunFacts.Entities
{
    public class TopicLabel
    {
        public Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public Guid LabelId { get; set; }
        public virtual Label Label { get; set; }
    }
}
