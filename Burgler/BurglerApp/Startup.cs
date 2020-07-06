using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BurglerContextLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Burgler.BusinessLogic.UserLogic;
using Burgler.BusinessLogic.JwtLogic;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Burgler.BusinessLogic.OrderLogic;
using Burgler.Entities.User;
using BurglerApp.Middleware;
using AutoMapper;
using BurglerApp.Authorisation;
using Burgler.BusinessLogic.MenuLogic;

namespace BurglerApp
{
    public class Startup
    {
        private readonly string AllowedOrigins = "AllowedOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<BurglerContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection"));
            });
            ConfigureServices(services);
        }
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<BurglerContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection"));
            });
            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy(name: AllowedOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                    })
            );
            services.AddControllersWithViews(
                opt =>
                {
                    //var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    //opt.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblyContaining<CreateCommand>();
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services
                //.AddIdentity<AppUser>()
                .AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<BurglerContext>()
                //.AddRoles<IdentityRole>()
                .AddUserManager<UserManager<AppUser>>()
                .AddSignInManager<SignInManager<AppUser>>();

            //var builder = services.AddIdentityCore<AppUser>();
            //var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            //identityBuilder.AddEntityFrameworkStores<BurglerContext>();
            //identityBuilder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("IsStaff", policy =>
                {
                    //policy.RequireRole();
                    policy.Requirements.Add(new IsStaffRequirement());
                });
            });
            services.AddTransient<IAuthorizationHandler, IsStaffRequirementHandler>();

            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IMenuServices, MenuServices>();

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IJwtServices, JwtServices>();

            services.AddAutoMapper(typeof(CreateCommand));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("burgler_secret_key"));
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });

            //services.AddAuthentication()
            //        .AddGoogle(options =>
            //        {
            //            // Read Google auth info from json file
            //            GoogleAuthInfo authInfo;

            //            using (StreamReader r = new StreamReader("google-auth.json"))
            //            {
            //                string json = r.ReadToEnd();
            //                authInfo = System.Text.Json.JsonSerializer.Deserialize<GoogleAuthInfo>(json);
            //            }

            //            options.ClientId = authInfo.web.client_id;
            //            options.ClientSecret = authInfo.web.client_secret;
            //        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Order of middleware is important:
            // Logging goes first, Error handling second
            app.UseMiddleware<ApiResponseLoggingMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //}

            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opt => opt.NoReferrer());
            app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
            app.UseXfo(opt => opt.Deny());
            app.UseCsp(opt => opt
                .BlockAllMixedContent()
                .StyleSources(s => s.Self().UnsafeInline()
                .CustomSources("https://fonts.googleapis.com/"))
                .FontSources(s => s.Self().CustomSources
                ("https://fonts.gstatic.com/"))
                .FormActions(s => s.Self())
                .FrameAncestors(s => s.Self())
                .ImageSources(s => s.Self().CustomSources("data:", "https://www.google-analytics.com/", "https://stats.g.doubleclick.net/", "https://www.facebook.com/tr/", "https://www.facebook.com/impression.php/"))
                .ScriptSources(s => s.Self()
                    .UnsafeInline()
                    .CustomSources("https://www.google-analytics.com/",
                    "https://www.googletagmanager.com/",
                    "https://apis.google.com/",
                    "https://connect.facebook.net/",
                    "http://connect.facebook.net/en_US/sdk.js"))
            );

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            //app.UseCors("CorsPolicy");
            app.UseCors(AllowedOrigins);

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
