using FunFacts.Entities.UserEntities;

namespace FunFacts.Infrastructure
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
        RefreshToken GenerateRefreshToken();
    }
}
