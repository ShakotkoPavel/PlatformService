namespace ApiService.Store.Services
{
    using ApiService.Core.Models;
    using Microsoft.EntityFrameworkCore;

    public class PlatformServiceDbContext : DbContext
    {
        public PlatformServiceDbContext(DbContextOptions<PlatformServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlatformModel> Platforms { get; set; }
    }
}