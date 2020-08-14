using System;
using System.Collections.Generic;
using System.Text;
using Burgler.Entities.OrderNS;

namespace Burgler.Entities.User
{
    public class UserOrder
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order OrderItem { get; set; }
        public DateTime DateOrdered { get; set; }
    }
}
