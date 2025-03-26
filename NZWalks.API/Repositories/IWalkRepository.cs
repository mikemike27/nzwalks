using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalkAsync(Walk walk);

        Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);

        Task<Walk?> GetWalkByIdAsync(Guid id);

        Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk);

        Task<Walk?> DeleteWalkByIdAsync(Guid id);
    }
}
