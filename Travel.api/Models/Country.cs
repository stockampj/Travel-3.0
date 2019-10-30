using System.Collections.Generic;

namespace Travel.Models
{
    public class Country
    {
        public Country()
            {
                this.Cities = new HashSet<City>();
            }
        public int CountryId {get; set;}
        public string CountryName {get; set;}
        public ICollection<City> Cities {get;}
    }
    

}