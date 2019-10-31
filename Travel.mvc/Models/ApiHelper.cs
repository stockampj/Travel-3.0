using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.mvc.Models
{
    class ApiHelper
    {
        public static async Task<string> ApiCallGet()
        {
            RestClient client = new RestClient("http://localhost:5000/api/reviews");
            RestRequest request = new RestRequest("/", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallGetCities()
        {
            RestClient client = new RestClient("http://localhost:5000/api/cities");
            RestRequest request = new RestRequest("/", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallGetCountries()
        {
            RestClient client = new RestClient("http://localhost:5000/api/countries");
            RestRequest request = new RestRequest("/", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> AddCity(City city)
        {
            RestClient client = new RestClient("http://localhost:5000/api/cities");
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(city);
            var response = await client.ExecuteTaskAsync(request);

            return response.Content;
        }

        public static async Task<string> DeleteCity(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/api/cities/" + id);
            RestRequest request = new RestRequest(Method.DELETE);
            var response = await client.ExecuteTaskAsync(request);

            return response.Content;
        }

        public static async Task<string> AddCountry(Country country)
        {
            RestClient client = new RestClient("http://localhost:5000/api/countries");
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(country);
            var response = await client.ExecuteTaskAsync(request);

            return response.Content;
        }
        public static async Task<string> DeleteCountry(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/api/countries/" + id);
            RestRequest request = new RestRequest(Method.DELETE);
            var response = await client.ExecuteTaskAsync(request);

            return response.Content;
        }
         public static async Task<string> DeleteReview(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/api/reviews/" + id);
            RestRequest request = new RestRequest(Method.DELETE);
            var response = await client.ExecuteTaskAsync(request);

            return response.Content;
        }
         public static async Task<string> AddReview(Review review)
        {
            RestClient client = new RestClient("http://localhost:5000/api/reviews");
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(review);
            var response = await client.ExecuteTaskAsync(request);

            return response.Content;
        }
          public static async Task<string> GetReview(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/api/Reviews?reviewId=" + id);
            RestRequest request = new RestRequest(Method.GET);
            var response = await client.ExecuteTaskAsync(request);

            return response.Content;
        }

        public static async Task<string> EditReview(Review review)
        {
            RestClient client = new RestClient("http://localhost:5000/api/Reviews/"+ review.ReviewId);
            RestRequest request = new RestRequest(Method.PUT);
            request.AddJsonBody(review);
            var response = await client.ExecuteTaskAsync(request);

            return response.Content;
        }



    }
}