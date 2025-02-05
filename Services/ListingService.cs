using RealEstateListingApi.Interfaces;
using RealEstateListingApi.Models;

namespace RealEstateListingApi.Services;

public class ListingService : IListingService
{
    private readonly IUnitOfWork _unitOfWork;

    public ListingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Listing>> GetAllListingsAsync()
    {
        return await _unitOfWork.Listings.GetAllAsync();
    }

    public async Task<Listing?> GetListingByIdAsync(string id)
    {
        return await _unitOfWork.Listings.GetByIdAsync(id);
    }

    public async Task<Listing> CreateListingAsync(Listing listing)
    {
        listing.Id = Guid.NewGuid().ToString();
        await _unitOfWork.Listings.AddAsync(listing);
        await _unitOfWork.CompleteAsync();
        return listing;
    }

    public async Task<bool> DeleteListingAsync(string id)
    {
        var deleted = await _unitOfWork.Listings.DeleteAsync(id);
        if (deleted)
        {
            await _unitOfWork.CompleteAsync();
            return true;
        }
        return false;
    }
} 