using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;


namespace NationalParks.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksApiContext _db;

    public ParksController(ParksApiContext db)
    {
      _db = db;
    }
    
    //GET api/parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get (string parkName, string parkCity, string parkState)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();
      
      if (parkName != null)
      {
        query = query.Where(e => e.ParkName == parkName);
      }
       if (parkCity != null)
      {
        query = query.Where(e => e.ParkCity == parkCity);
      }
      if (parkState != null)
      {
        query = query.Where(e => e.ParkState == parkState);
      }
    
      return await query.ToListAsync();
    }

    // Post api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(Post), new { id = park.ParkId }, park);
    }

    //Get api/Parks/{id}

    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      
      if (park == null)
      {
          return NotFound();
      }
      return park;
    }

    //put api/Parks/2
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Parks.Update(park);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return Ok();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    
    }

    // DELETE: api/Parks/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
