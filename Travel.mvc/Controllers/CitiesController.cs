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
    }
}
