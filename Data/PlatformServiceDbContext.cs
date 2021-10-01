namespace PlatformService.Data
{
    using Microsoft.EntityFrameworkCore;
    using PlatformService.Models;

    public class PlatformServiceDbContext : DbContext
    {
        public PlatformServiceDbContext(DbContextOptions<PlatformServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}