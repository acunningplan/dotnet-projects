using Burgler.Entities.User;

namespace Burgler.BusinessLogic.JwtLogic
{
    public interface IJwtServices
    {
        string CreateToken(AppUser user);
    }
}
