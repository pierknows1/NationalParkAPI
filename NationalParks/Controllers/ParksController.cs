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
    // GET api/parks
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Park>>> Get (string ParkName, string ParkCity, string ParkState)
    // {
    //   IQueryable<Park> query = _db.Parks.AsQueryable();
      
    //   if (ParkName != null)
    //   {
    //     query = query.Where(entry => entry.ParkName == ParkName);
    //   }
    //    if (ParkCity != null)
    //   {
    //     query = query.Where(entry => entry.ParkCity == ParkCity);
    //   }
    //   if (ParkState != null)
    //   {
    //     query = query.Where(entry => entry.ParkState == ParkState);
    //   }
    
    //   return await query.ToListAsync();
    // }
  }
}