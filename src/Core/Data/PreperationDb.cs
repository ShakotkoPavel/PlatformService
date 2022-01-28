namespace PlatformService.Data
{
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using PlatformService.Models;

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
                    new Platform { Name = ".NET", Publisher = "Contoso", Cost = "Free" },
                    new Platform { Name = "Java", Publisher = "Oracle", Cost = "$1" },
                    new Platform { Name = "JavaScript", Publisher = "Google", Cost = "$10" },
                    new Platform { Name = "Golang", Publisher = "Apache", Cost = "$20" });

                platformServiceDbContext.SaveChanges();
            }
            else
            {
            }
        }
    }
}