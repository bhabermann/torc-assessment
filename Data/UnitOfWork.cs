using RealEstateListingApi.Interfaces;
using RealEstateListingApi.Repositories;

namespace RealEstateListingApi.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IListingRepository _listings;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _listings = new ListingRepository(_context);
    }

    public IListingRepository Listings => _listings;

    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
} 