using Microsoft.AspNetCore.Mvc;
using RealEstateListingApi.Interfaces;
using RealEstateListingApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateListingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingsController(IListingService listingService)
        {
            _listingService = listingService;
        }

        // Tag this operation as "Listings Retrieval"
        [HttpGet]
        [Tags("Listings Retrieval")]
        public async Task<ActionResult<IEnumerable<Listing>>> GetAllListings()
        {
            var listings = await _listingService.GetAllListingsAsync();
            return Ok(listings);
        }

        // Tag this operation as "Listings Management"
        [HttpPost]
        [Tags("Listings Management")]
        public async Task<ActionResult<Listing>> AddListing([FromBody] Listing listing)
        {
            var newListing = await _listingService.CreateListingAsync(listing);
            return CreatedAtAction(nameof(GetListingById), new { id = newListing.Id }, newListing);
        }

        // Tag this operation as "Listings Retrieval"
        [HttpGet("{id}")]
        [Tags("Listings Retrieval")]
        public async Task<ActionResult<Listing>> GetListingById(string id)
        {
            var listing = await _listingService.GetListingByIdAsync(id);
            if (listing == null)
            {
                return NotFound();
            }
            return Ok(listing);
        }

        // Tag this operation as "Listings Management"
        [HttpDelete("{id}")]
        [Tags("Listings Management")]
        public async Task<IActionResult> DeleteListing(string id)
        {
            var result = await _listingService.DeleteListingAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
