using System.Collections.Generic;
namespace Travel.Models
{
    public class City 
    {
        // public double Rating {get; set;}
        public City()
        {
            this.Reviews = new HashSet<Review>();
        }
        
        public string CityName {get; set;}
        public int ReviewCount {get; set;}
        public int CityId {get; set;}
        public double Rating {get; set;}
        public int CountryId {get; set;}
        public ICollection<Review> Reviews {get;}
    }
}