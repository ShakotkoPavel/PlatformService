namespace ApiService.DataAccess.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApiService.Core.Abstraction;
    using ApiService.Core.Models;
    using Microsoft.EntityFrameworkCore;

    public class PlatformServiceRepository : IPlatformServiceRepository
    {
        private readonly PlatformServiceDbContext _platformServiceDbContext;

        public PlatformServiceRepository(PlatformServiceDbContext platformServiceDbContext)
        {
            _platformServiceDbContext = platformServiceDbContext;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _platformServiceDbContext.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<PlatformModel>> GetPlatformsAsync()
        {
            return await _platformServiceDbContext.Platforms.ToListAsync();
        }

        public async Task<PlatformModel> GetPlatformIdAsync(int id)
        {
            return await _platformServiceDbContext.Platforms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreatePlatformAsync(PlatformModel plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            await _platformServiceDbContext.Platforms.AddAsync(plat);
            await _platformServiceDbContext.SaveChangesAsync();
        }
    }
}