using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Travel.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get(string userName)
        {
            var query = _db.Users
                .Include(user => user.Reviews)
                .AsQueryable();

            if(userName != null)
            {
              query = query
                .Include(user => user.Reviews)
                .Where(entry => entry.UserName.ToLower().Replace(" ", "") == userName.ToLower().Replace(" ", ""));
            }

            return query.ToList();
        }
        // POST api/animals
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            user.UserId = id;
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}