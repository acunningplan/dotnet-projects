using FunFacts.Entities.User;

namespace FunFacts.Entities.Images
{
    public class UserPhoto : Image
    {
        public virtual AppUser User { get; set; }
        public string AppUserId { get; set; } = "";
    }
}
