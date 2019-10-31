using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.mvc.Models
{
    public class Review
    {
        public int ReviewId {get; set;}
        public string Blurb {get; set;}
        public double Rating {get;set;}
        public int UserId {get; set;}
        public int CityId {get; set;}

        public static List<Review> GetReviews()
        {
            var apiCallTask = ApiHelper.ApiCallGet();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);

            List<Review> reviewList = new List<Review> ();
            foreach (JObject reviewJSON in jsonResponse)
            {
                Review  newReview = JsonConvert.DeserializeObject<Review> (reviewJSON.ToString());
                reviewList.Add(newReview);
            }
        return reviewList;

        }

        public static List<Review> GetReview(int id)
        {
            var apiCallTask = ApiHelper.GetReview(id);
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);

            List<Review> reviewList = new List<Review> ();
            foreach (JObject reviewJSON in jsonResponse)
            {
                Review  newReview = JsonConvert.DeserializeObject<Review> (reviewJSON.ToString());
                reviewList.Add(newReview);
            }
        return reviewList;

        }

    }
}