namespace ApiService.Infra
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class Module
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var commandServiceConfiguration = configuration.GetSection("CommandServiceConfiguration").Get<CommandServiceConfiguration>();
            services.AddSingleton(commandServiceConfiguration);

            services.AddHttpClient<ICommandServiceClient, CommandServiceClient>();

            return services;
        }
    }
}