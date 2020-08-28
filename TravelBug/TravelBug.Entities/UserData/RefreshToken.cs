using System;

namespace TravelBug.Entities.UserData
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual string Token { get; set; }
        public DateTime Expires { get; set; } = DateTime.UtcNow.AddDays(7);
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}