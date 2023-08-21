using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;

namespace NationalParks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParkController : ControllerBase
  {
    private readonly ParksApiContext _db;

    
    public ParkController(ParksApiContext db)
    {
      _db = db;
    }
    // GET api/parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get (string ParkName, string ParkCity, string ParkState)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();
      
      if (ParkName != null)
      {
        query = query.Where(entry => entry.ParkName == ParkName);
      }
       if (ParkCity != null)
      {
        query = query.Where(entry => entry.ParkCity == ParkCity);
      }
      if (ParkState != null)
      {
        query = query.Where(entry => entry.ParkState == ParkState);
      }
      if (rating > 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      return await query.ToListAsync();
    }
  }
}