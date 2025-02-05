using Microsoft.EntityFrameworkCore;
using RealEstateListingApi.Data;
using RealEstateListingApi.Interfaces;
using RealEstateListingApi.Models;

namespace RealEstateListingApi.Repositories;

public class ListingRepository(ApplicationDbContext context) : IListingRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Listing>> GetAllAsync()
    {
        return await _context.Listings.ToListAsync();
    }

    public async Task<Listing?> GetByIdAsync(string id)
    {
        return await _context.Listings.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Listing> AddAsync(Listing listing)
    {
        await _context.Listings.AddAsync(listing);
        return listing;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
} 