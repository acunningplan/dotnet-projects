using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelBug.Infrastructure;
using TravelBug.Entities.UserData;
using TravelBug.Infrastructure.UserLogic;
using static TravelBug.Infrastructure.ExternalLoginService;
using System.Net.Http;
using System;
using TravelBug.Infrastructure.Exceptions;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TravelBug.Dtos;

namespace TravelBug.Web.Controllers
{
  [ApiController]
  [Route("api/user")]
  public class UserController : ControllerBase
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IRequestUsersService _requestUsersService;
    private readonly ILoginService _loginService;
    private readonly IRegisterService _registerService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IExternalLoginService _externalLogin;
    private readonly IEmailConfirmation _emailConfirmation;
    private readonly IFeaturedUsersService _featuredUsersService;
    private readonly IConfiguration _config;

    public UserController(
        IHttpClientFactory httpClientFactory,
        IRequestUsersService requestUsersService,
        ILoginService loginService,
        IRegisterService registerService,
        IRefreshTokenService refreshTokenService,
        IExternalLoginService externalLogin,
        IEmailConfirmation emailConfirmation,
        IFeaturedUsersService featuredUsersService,
        IConfiguration config)
    {
      _httpClientFactory = httpClientFactory;
      _requestUsersService = requestUsersService;
      _loginService = loginService;
      _registerService = registerService;
      _refreshTokenService = refreshTokenService;
      _externalLogin = externalLogin;
      _emailConfirmation = emailConfirmation;
      _featuredUsersService = featuredUsersService;
      _config = config;
    }


    [HttpGet]
    public async Task<User> GetCurrentUserProfile()
    {
      return await _loginService.GetUserProfile();
    }

    [HttpGet("{username}")]
    public async Task<User> GetUserProfile(string username)
    {
      return await _requestUsersService.GetUser(username);
    }


    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<User> Login(LoginInput loginInput)
    {
      return await _loginService.Login(loginInput);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task Register(RegisterInput registerInput)
    {
      // var origin = registerInput.Origin;
      var origin = Request.Headers["origin"];

      var emailToken = await _registerService.GenerateEmailToken(registerInput);

      var emailVerificationUrl = $"{origin}/verify-email?token={emailToken}&email={registerInput.Email}";
      // var emailVerificationUrl = $"http://localhost:5000/api/user/verify-email?token={emailToken}&email={registerInput.Email}";

      await _registerService.SendEmail(registerInput.Email, emailVerificationUrl);
    }

    [AllowAnonymous]
    [HttpPost("verify-email")]
    public async Task VerifyEmail(VerifyEmailInput verifyEmailInput)
    {
      await _registerService.VerifyEmail(verifyEmailInput);
    }

    [AllowAnonymous]
    [HttpPost("resend-email-verification")]
    public async Task ResendEmailVerification(ResendEmailInput input)
    {
      input.Origin = Request.Headers["origin"];
      await _emailConfirmation.ResendEmail(input);
    }

    [AllowAnonymous]
    [HttpPost("facebook-login")]
    public async Task<ActionResult<User>> FacebookLogin(UserData request)
    {
      // Verify facebook token
      var httpClient = _httpClientFactory.CreateClient();
      httpClient.BaseAddress = new Uri("https://graph.facebook.com/");

      var appId = _config["Facebook:AppId"];
      var appSecret = _config["Facebook:AppSecret"];

      var response = await httpClient.GetAsync($"debug_token?input_token={request.AccessToken}&access_token={appId}|{appSecret}");

      if (!response.IsSuccessStatusCode)
        throw new RestException(HttpStatusCode.BadRequest, new { User = "Problem validating token" });

      // Save user data
      return await _externalLogin.SaveUser(request, "facebook");
    }


    [AllowAnonymous]
    [HttpPost("google-login")]
    public async Task<ActionResult<User>> GoogleLogin(UserData request)
    {
      // Verify google token
      var httpClient = _httpClientFactory.CreateClient();
      httpClient.BaseAddress = new Uri("https://www.googleapis.com/oauth2/v3/");

      var response = await httpClient.GetAsync($"tokeninfo?access_token={request.AccessToken}");

      if (!response.IsSuccessStatusCode)
        throw new RestException(HttpStatusCode.BadRequest, new { User = "Problem validating token" });

      // Save user data
      return await _externalLogin.SaveUser(request, "google");
    }

    [HttpPost("refreshToken")]
    public async Task<User> RefreshToken(string refreshToken)
    {
      return await _refreshTokenService.GetRefreshToken(refreshToken);
    }

    [HttpPost("edit-profile")]
    public async Task<ActionResult> EditProfile()
    {
      return Ok();
    }


    [HttpGet("featured")]
    public async Task<List<User>> FeaturedUsers()
    {

      return await _featuredUsersService.GetFeaturedUsers();
    }
  }
}
