using FunFacts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunFacts.Dtos
{
    public class TopicDto : Base
    {
        public string Introduction { get; set; }
        public virtual string CreatedByUser { get; set; }
        public virtual ICollection<FunFactDto> FunFacts { get; set; } = new List<FunFactDto>();
        public virtual ICollection<LabelDto> Labels { get; set; } = new List<LabelDto>();
    }
}
