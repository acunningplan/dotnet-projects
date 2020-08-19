using System;

namespace TravelBug.CrudData
{
    public class Base : IBase
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? Deleted { get; set; }
    }
}
