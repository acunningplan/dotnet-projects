using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TravelBug.Infrastructure;
using TravelBug.Context;
using TravelBug.CrudServices;
using TravelBug.Entities.UserData;
using TravelBug.FollowingServices;
using TravelBug.Web.Authorization;
using TravelBug.Web.Middleware;
using Newtonsoft.Json;
using AutoMapper;
using TravelBug.Entities;
using TravelBug.Infrastructure.PhotoLogic;
using TravelBug.PhotoServices;
using System.Net.Http;
using TravelBug.Infrastructure.UserLogic;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

namespace TravelBug
{
    public class Startup
    {
        //private readonly string AllowedOrigins = "AllowedOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TravelBugContext>(opt =>
            {
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(options =>
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                    })
            );

            //services.AddCors(options =>
            //    options.AddPolicy(name: "newPolicy",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:5000", "https://localhost:5001")
            //              .AllowAnyMethod()
            //              .AllowAnyHeader();
            //        })
            //);

            services.AddAutoMapper(typeof(User), typeof(BlogService));
            services.AddControllersWithViews(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            })
                .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 });
            //.AddFluentValidation(cfg =>
            //{
            //    //cfg.RegisterValidatorsFromAssemblyContaining<Create>();
            //});

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //var builder = services.AddIdentityCore<AppUser>();
            //var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            //identityBuilder.AddEntityFrameworkStores<TravelBugContext>();
            //identityBuilder.AddSignInManager<SignInManager<AppUser>>();

            services.TryAddSingleton<ISystemClock, SystemClock>();

            services
                .AddIdentityCore<AppUser>(options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    //options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<TravelBugContext>()
                //.AddRoles<IdentityRole>()
                .AddUserManager<UserManager<AppUser>>()
                .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("IsBlogAuthor", policy =>
                {
                    policy.Requirements.Add(new IsAuthorRequirement());
                });
            });
            services.AddTransient<IAuthorizationHandler, IsAuthorRequirementHandler>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["travel_bug_token_key"]));
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Google:ClientSecret"];
                });

            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IExternalLoginService, ExternalLoginService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IFollowingService, FollowingService>();
            services.AddScoped<IFollowerListingService, FollowerListingService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IBlogService, BlogService>();

            var mailKitOptions = Configuration.GetSection("MailKitOptions").Get<MailKitOptions>();
            services.AddMailKit(options => options.UseMailKit(mailKitOptions));


            services.AddHttpClient();

            services.Configure<ImgurSettings>(Configuration.GetSection("Imgur"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            //app.UseCors("newPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
