using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ParksController(ParksApiContext db)
        {
            _db = db;
        }

        // GET api/parks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Park>>> Get(string parkName, string parkCity, string parkState, int page = 1, int pageSize = 2)
        {
            IQueryable<Park> query = _db.Parks.AsQueryable();

            if (!string.IsNullOrEmpty(parkName))
            {
                query = query.Where(e => e.ParkName == parkName);
            }
            if (!string.IsNullOrEmpty(parkCity))
            {
                query = query.Where(e => e.ParkCity == parkCity);
            }
            if (!string.IsNullOrEmpty(parkState))
            {
                query = query.Where(e => e.ParkState == parkState);
            }

            //added pagination to Get because my newtonsoft.json didnt work

            int totalCount = await query.CountAsync();
            int skip = (page - 1) * pageSize;

            List<Park> parks = await query
                  .Skip(skip)
                  .Take(pageSize)
                  .ToListAsync();

            // Wont change DB 
            //If the user tries to get to the 4th page, he will get empty args
            var response = new
            {
                QueriedParks = parks,
                MatchingParks = parks.Count, //how many parks will show based on the number page one is on, anything beyond 3 will be 0
                TotalParks = totalCount,     // how many parks are in the db
                CurrentPage = page,          // current page ID 
                ParksPerPage = pageSize      // how many parks show per page
            };

    return Ok(response);
}

        // POST api/parks
        [HttpPost]
        public async Task<ActionResult<Park>> Post(Park park)
        {
            _db.Parks.Add(park);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = park.ParkId }, park);
        }

        // GET api/parks/{id}
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

        // PUT api/parks/{id}
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

        // DELETE api/parks/{id}
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
