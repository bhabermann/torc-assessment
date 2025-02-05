using RealEstateListingApi.Models;

namespace RealEstateListingApi.Interfaces;

public interface IListingRepository
{
    Task<IEnumerable<Listing>> GetAllAsync();
    Task<Listing?> GetByIdAsync(string id);
    Task<Listing> AddAsync(Listing listing);
    Task<bool> DeleteAsync(string id);
}