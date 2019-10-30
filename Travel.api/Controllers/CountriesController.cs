using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private ApplicationDbContext _db;

        public CountriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Country>> Get(string countryName)
        {
            var query = _db.Countries.AsQueryable();
            if(countryName != null)
            {
              query = query
                .Include(country => country.Cities)
                .ThenInclude(city => city.Reviews)
                .Where(entry => entry.CountryName == countryName);
            }
            return query.ToList();
        }
        // POST api/animals
        [HttpPost]
        public void Post([FromBody] Country country)
        {
            _db.Countries.Add(country);
            _db.SaveChanges();
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Country country)
        {
            country.CountryId = id;
            _db.Entry(country).State = EntityState.Modified;
            _db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var countryToDelete = _db.Countries.FirstOrDefault(entry => entry.CountryId == id);
            _db.Countries.Remove(countryToDelete);
            _db.SaveChanges();
        }
    }
}