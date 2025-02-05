using RealEstateListingApi.Interfaces;
using RealEstateListingApi.Models;

namespace RealEstateListingApi.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _repository;


    public ListingService(IListingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Listing>> GetAllListingsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Listing?> GetListingByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Listing> CreateListingAsync(Listing listing)
    {
        listing.Id = Guid.NewGuid().ToString();
        await _repository.AddAsync(listing);
        await _repository.SaveChangesAsync();
        return listing;
    }
} 