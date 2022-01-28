namespace PlatformService.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PlatformService.Models;

    public interface IPlatformServiceRepository
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Platform>> GetPlatformsAsync();

        Task<Platform> GetPlatformIdAsync(int id);

        Task CreatePlatformAsync(Platform plat);
    }
}