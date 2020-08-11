using LoginJWT;
using MemberOutReachSystem.Business;
using MemberOutReachSystem.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;
using System.Net.Http;

namespace MemberOutreachSystem.MemberAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IWebHostEnvironment HostingEnvironment { get; set; } //NOSONAR
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MemberDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MemberManagement")));
            

            var key = "this is my custom Secret key for authnetication";

            IConfigurationBuilder builder = new ConfigurationBuilder();
            services.AddJwtAuthentication(HostingEnvironment, builder);

            services.AddSingleton<ITokenBuilder>(new TokenBuilder(key));


            services.AddControllers();


            var basicCircuitBreakerpolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(2, TimeSpan.FromMinutes(2));


            services.AddHttpClient("MemberApi", C =>
            {
                C.BaseAddress = new Uri("http://localhost:50398");  //NOSONAR
                C.DefaultRequestHeaders.Add("Accept", "application/json");
            })
                .AddPolicyHandler(basicCircuitBreakerpolicy);
               

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//NOSONAR
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
