using System;

namespace TravelBug.CrudData
{
    public interface IBase
    {
        int Id { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        DateTimeOffset? Deleted { get; set; }
    }
}