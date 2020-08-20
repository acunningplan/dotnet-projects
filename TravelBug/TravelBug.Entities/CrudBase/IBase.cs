using System;

namespace TravelBug.Entities
{
    public interface IBase
    {
        Guid Id { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        DateTimeOffset? Deleted { get; set; }
    }
}