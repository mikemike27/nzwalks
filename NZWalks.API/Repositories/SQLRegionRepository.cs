using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> DeleteRegionByIdAsync(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null) {
                return null;
            }

            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateRegionByIdAsync(Guid id, Region region)
        {
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null) {
                return null;
            }

            regionDomainModel.Code = region.Code;
            regionDomainModel.Name = region.Name;
            regionDomainModel.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return regionDomainModel;
        }
    }
}
