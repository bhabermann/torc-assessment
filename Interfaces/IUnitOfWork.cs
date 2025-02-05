namespace RealEstateListingApi.Interfaces;

public interface IUnitOfWork
{
    IListingRepository Listings { get; }
    Task<bool> CompleteAsync();
} 