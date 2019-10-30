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
  
    // public static async Task<string> ApiCallPostIndex()
    // {
    //   RestClient client = new RestClient("http://localhost:5000/api/post");
    //   RestRequest request = new RestRequest(Method.POST);
    //   var response = await client.ExecuteTaskAsync(request);
    //   return response.Content;
    // }
  }
}