using System;

namespace TravelBug.Entities
{
    public class Base : IBase
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? Deleted { get; set; }
    }
}
