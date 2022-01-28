using System.Collections.Generic;
using System.Threading.Tasks;
using ApiService.Core.Models;

namespace ApiService.Core.Abstraction
{
    public interface IPlatformServiceRepository
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<PlatformModel>> GetPlatformsAsync();

        Task<PlatformModel> GetPlatformIdAsync(int id);

        Task CreatePlatformAsync(PlatformModel plat);
    }
}