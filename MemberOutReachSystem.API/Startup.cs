using LoginJWT;
using MemberOutReachSystem.Business;
using MemberOutReachSystem.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MemberOutReachSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //NOSONAR
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private ConfigurationSetting _configurationSetting;

        private IWebHostEnvironment HostingEnvironment { get; } //NOSONAR



        public Startup(IWebHostEnvironment env)
        {
            // In ASP.NET Core 3.0 `env` will be an IWebHostEnvironment, not IHostingEnvironment.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserManagement")));

            services.AddDbContextPool<MemberDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MemberManagement")));

            services.AddDbContextPool<OutreachDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OutreachSystem")));
            
            services.AddScoped<IUserRepository, UserRepository>();

            var key = "this is my custom Secret key for authnetication";

            IConfigurationBuilder builder = new ConfigurationBuilder();
            services.AddJwtAuthentication(HostingEnvironment, builder);


            services.AddSingleton<ITokenBuilder>(new TokenBuilder(key));
            
            services.AddApiVersioning();

            services.AddSwaggerGen(S =>
                {
                    S.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API Details", Version = "v1" });
                    S.ResolveConflictingActions(apiDesc => apiDesc.First());                    
                }
            );
            
            _configurationSetting = services.RegisterConfiguration(Configuration);
            services.AddConsulConfig(_configurationSetting);

            services.AddControllers();

            services.AddOptions();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
             
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;

            }
            ) ;

            app.UseSwaggerUI(c =>
             {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Details");                               
                 
             }
            );

            app.UseConsul(_configurationSetting);


            loggerFactory.AddFile("logs/ApiLog-{Date}.txt");
        }

    }
}
