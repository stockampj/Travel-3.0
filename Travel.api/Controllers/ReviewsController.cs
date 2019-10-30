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
    public class ReviewsController : ControllerBase
    {
        private ApplicationDbContext _db;

        public ReviewsController(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// You may enter a String with a City ID or a rating minimum to filter your searches.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get(string cityId, string rating)
        {
            var query = _db.Reviews.AsQueryable();

            if(cityId != null)
            {
            int cityIdInt = Int32.Parse(cityId);
            query = query
                .Where(review => review.CityId == cityIdInt);
            }

            if(rating != null)
            {
            double ratingDouble = Double.Parse(rating);
            query = query
                .Where(review => review.Rating >= ratingDouble);
            }

            return query.ToList();
        }
        // POST api/animals
        [HttpPost]
        public void Post([FromBody] Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();


            List<Review> reviews = _db.Reviews
                .Where(entry => entry.CityId == review.CityId)
                .ToList();
            double ratingSum = 0;
            foreach (Review entry in reviews)
            {
                ratingSum+= entry.Rating;
            }
            double average = ratingSum/reviews.Count;
            City cityToUpdate = _db.Cities
                .FirstOrDefault(city => city.CityId == review.CityId);
            cityToUpdate.Rating = average;
            cityToUpdate.ReviewCount = reviews.Count;
            _db.Entry(cityToUpdate).State = EntityState.Modified;
            _db.SaveChanges();

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Review review)
        {
            review.ReviewId = id;
            _db.Entry(review).State = EntityState.Modified;
            _db.SaveChanges();

            List<Review> reviews = _db.Reviews
                .Where(entry => entry.CityId == review.CityId)
                .ToList();
            double ratingSum = 0;
            foreach (Review entry in reviews)
            {
                ratingSum+= entry.Rating;
            }
            double average = ratingSum/reviews.Count;
            City cityToUpdate = _db.Cities
                .FirstOrDefault(city => city.CityId == review.CityId);
            cityToUpdate.Rating = average;
            _db.Entry(cityToUpdate).State = EntityState.Modified;
            _db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
            _db.Reviews.Remove(reviewToDelete);
            _db.SaveChanges();
        }
    }
}