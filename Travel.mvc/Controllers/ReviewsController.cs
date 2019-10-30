using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.mvc.Models;

namespace TravelClient.mvc.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Show(int id)
        {
            var allReviews = Review.GetReviews();
            List<Review> targetCityReviews = new List<Review> {};
            foreach (Review review in allReviews) 
            {
                if (review.CityId == id)
                {
                    targetCityReviews.Add(review);
                }
            }

            return View(targetCityReviews);
        }
    }
}
