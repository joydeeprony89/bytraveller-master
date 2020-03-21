//---------------------------------------------------------------------------------------------
// <copyright file= Startup.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using ByTraveller.BusinessImpl.Users;
using ByTravellerAPI.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Options;
using ByTraveller.Business.Login;
using ByTraveller.BusinessImpl.Login;
using ByTraveller.Provider;
using ByTraveller.ProviderImpl;
using ByTraveller.EntityFramework;
using Microsoft.EntityFrameworkCore;
using TokenService.Interface;
using TokenService.Implementation;
using ByTraveller.Business.Users;

namespace ByTravellerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationContext>(options => 
            options.UseSqlServer("Data Source=localhost; Initial Catalog=byTravellerDev; User ID=ByTravellerAdmin; Password=ByTravellerAdmin"));
            services.AddScoped<ILoginBusiness, LoginBusniess>();
            services.AddScoped<ITokenManagerService, TokenManagerService>();
            services.AddScoped<ILoginDataHandler, LoginDataHandler>();
            services.AddScoped<IUserDataHandler, UserDataHandler>();
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IUsersBusiness, UsersBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
