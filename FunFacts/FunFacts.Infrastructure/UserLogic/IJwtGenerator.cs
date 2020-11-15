using FunFacts.Entities.User;

namespace FunFacts.Infrastructure
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
        RefreshToken GenerateRefreshToken();
    }
}
