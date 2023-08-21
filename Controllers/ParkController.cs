using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;

namespace NationalParks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksApiContext _db;

    
    public DestinationsController(TravelAPIContext db)
    {
      _db = db;
    }
    // GET api/destinations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get (int destinationId, string cityName, string countryName, string review, int rating )
    {
      IQueryable<Destination> query = _db.Destinations.AsQueryable();
      
      if (cityName != null)
      {
        query = query.Where(entry => entry.CityName == cityName);
      }
       if (countryName != null)
      {
        query = query.Where(entry => entry.CountryName == countryName);
      }
      if (rating > 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      return await query.ToListAsync();
    }
  }
}