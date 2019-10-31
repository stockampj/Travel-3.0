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
            ViewBag.CityId = id;

            return View(targetCityReviews);
        }
         public IActionResult Create(int id)
        {
             ViewBag.CityId = id;
             return View();
        }
        [HttpPost]
        public IActionResult Create(Review review)
        {
            ApiHelper.AddReview(review);
            return RedirectToAction("Show", "Reviews", new {id = review.CityId});
        }
        
          public IActionResult Delete(int id)
        {
            ApiHelper.DeleteReview(id);
            return RedirectToAction("Index", "Home");
        }
         public IActionResult Edit(int id)
        {
            List<Review> reviewInList = Review.GetReview(id);

            return View(reviewInList[0]);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            ApiHelper.EditReview(review);
            return RedirectToAction("Show", "Reviews", new {id = review.CityId});
        }


    }
}
