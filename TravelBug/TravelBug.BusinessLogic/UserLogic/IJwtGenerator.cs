using TravelBug.Entities.User;

namespace TravelBug.BusinessLogic
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}