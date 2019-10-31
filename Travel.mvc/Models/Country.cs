using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.mvc.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public static List<Country> GetCountries()
        {
            var apiCallTask = ApiHelper.ApiCallGetCountries();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);

            List<Country> countryList = new List<Country>();
            foreach (JObject countryJSON in jsonResponse)
            {
                Country newCountry = JsonConvert.DeserializeObject<Country>(countryJSON.ToString());
                countryList.Add(newCountry);
            }
            return countryList;

        }
    }
}

