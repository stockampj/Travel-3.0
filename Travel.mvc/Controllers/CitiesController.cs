using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.mvc.Models;

namespace TravelClient.mvc.Controllers
{
    public class CitiesController : Controller
    {
        public IActionResult Index()
        {
            var allCities = City.GetCities();
            return View(allCities);
        }
        public IActionResult Create(int id)
        {
             ViewBag.CountryId = id;
             return View();
        }
        [HttpPost]
        public IActionResult Create(City city)
        {


            ApiHelper.AddCity(city);
            return RedirectToAction("Index");
        }
        public IActionResult Show(int id)
        {
             var allCities = City.GetCities();
            List<City> targetCountryCities = new List<City> {};
           
           foreach (City city in allCities) 
            {
                if (city.CountryId == id)
                {
                    targetCountryCities.Add(city);
                }
            }
            ViewBag.CountryId = id;

            return View(targetCountryCities);
        }

    }

}
