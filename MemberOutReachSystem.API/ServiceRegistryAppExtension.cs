using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MemberOutReachSystem.API
{
    public static class ServiceRegistryAppExtension
    {
        public static IServiceCollection AddConsulConfig(this IServiceCollection services, ConfigurationSetting configurationSetting)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new Uri(configurationSetting.ConsulAddress);
            }));
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, ConfigurationSetting configurationSetting)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();            
            
            
            var registration = new AgentServiceRegistration()
            {
                ID = configurationSetting.ServiceName, //{uri.Port}",
                // servie name  
                Name = configurationSetting.ServiceName,
                Address = configurationSetting.ServiceHost, //$"{uri.Host}",
                Port = configurationSetting.ServicePort  // uri.Port
            };

           
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

           

            return app;
        }


    }

   

    public partial class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
