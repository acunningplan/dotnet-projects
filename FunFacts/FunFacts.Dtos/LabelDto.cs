using FunFacts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunFacts.Dtos
{
    public class LabelDto
    {
        public string Name { get; set; }
        public virtual ICollection<TopicLabel> Topics { get; set; }
    }
}
