using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.mvc.Models;

namespace TravelClient.mvc.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            var allCountries = Country.GetCountries();
            return View(allCountries);
        }

        public IActionResult Create()
        {
             return View();
        }
        [HttpPost]
        public IActionResult Create(Country country)
        {
            ApiHelper.AddCountry(country);
            return RedirectToAction("Index", "Countries");
        }
        
        public IActionResult Delete(int id)
        {
            ApiHelper.DeleteCountry(id);
            return RedirectToAction("Index");
        }

    }

}
