using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionsAsync();

        Task<Region?> GetRegionByIdAsync(Guid id);

        Task<Region> CreateRegionAsync(Region region);

        Task<Region?> UpdateRegionByIdAsync(Guid id, Region region);

        Task<Region?> DeleteRegionByIdAsync(Guid id);
    }
}
