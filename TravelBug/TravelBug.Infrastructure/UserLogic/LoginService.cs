//using FluentValidation;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;
using TravelBug.Dtos;
using TravelBug.Entities.UserData;
using TravelBug.Infrastructure.Exceptions;

namespace TravelBug.Infrastructure
{
  public interface ILoginService
  {
    Task<User> Login(LoginInput input);
  }

  public class LoginInput
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }

  public class LoginService : ILoginService
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IMapper _mapper;
    private readonly IUserAccessor _userAccessor;

    public LoginService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator, IMapper mapper, IUserAccessor userAccessor)
    {
      _signInManager = signInManager;
      _jwtGenerator = jwtGenerator;
      _mapper = mapper;
      _userManager = userManager;
      _userAccessor = userAccessor;
    }

    // Login by email and password
    public async Task<User> Login(LoginInput input)
    {
      var user = await _userManager.FindByEmailAsync(input.Email);

      if (user == null)
        throw new RestException(HttpStatusCode.Unauthorized, "Cannot find user");

      var result = await _signInManager
          .CheckPasswordSignInAsync(user, input.Password, false);

      if (result.Succeeded)
      {
        var refreshToken = _jwtGenerator.GenerateRefreshToken();
        user.RefreshTokens.Add(refreshToken);
        await _userManager.UpdateAsync(user);

        var returnedUser = _mapper.Map<AppUser, User>(user);
        returnedUser.Token = _jwtGenerator.CreateToken(user);
        returnedUser.RefreshToken = refreshToken.Token;

        return returnedUser;
      }
      throw new RestException(HttpStatusCode.Unauthorized, "Cannot sign in user");
    }
  }
}