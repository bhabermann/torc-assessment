using RealEstateListingApi.Models;

namespace RealEstateListingApi.Interfaces;

public interface IListingService
{
    Task<IEnumerable<Listing>> GetAllListingsAsync();
    Task<Listing?> GetListingByIdAsync(string id);
    Task<Listing> CreateListingAsync(Listing listing);
    Task<bool> DeleteListingAsync(string id);
} 