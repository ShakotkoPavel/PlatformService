namespace ApiService.DataAccess
{
    using System.Linq;
    using ApiService.Core.Models;
    using ApiService.DataAccess.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class PreperationDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using var service = applicationBuilder.ApplicationServices.CreateScope();
            SeedData(service.ServiceProvider.GetService<PlatformServiceDbContext>());
        }

        private static void SeedData(PlatformServiceDbContext platformServiceDbContext)
        {
            if (!platformServiceDbContext.Platforms.Any())
            {
                platformServiceDbContext.Platforms.AddRange(
                    new PlatformModel { Name = ".NET", Publisher = "Contoso", Cost = "Free" },
                    new PlatformModel { Name = "Java", Publisher = "Oracle", Cost = "$1" },
                    new PlatformModel { Name = "JavaScript", Publisher = "Google", Cost = "$10" },
                    new PlatformModel { Name = "Golang", Publisher = "Apache", Cost = "$20" });

                platformServiceDbContext.SaveChanges();
            }
            else
            {
            }
        }
    }
}