using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.mvc.Models
{
    public class City
    {
        public string CityName {get; set;}
        public int ReviewCount {get; set;}
        public int CityId {get; set;}
        public double Rating {get; set;}
        public int CountryId {get; set;}

        public static List<City> GetCities()
        {
            var apiCallTask = ApiHelper.ApiCallGetCities();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);

            List<City> cityList = new List<City> ();
            foreach (JObject cityJSON in jsonResponse)
            {
                City  newCity = JsonConvert.DeserializeObject<City> (cityJSON.ToString());
                cityList.Add(newCity);
            }
        return cityList;
        }

    }
}