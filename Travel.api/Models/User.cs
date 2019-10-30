using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Travel.Models
{
    public class User
    {
        public User()
        {
            this.Reviews = new HashSet<Review>();
        }
        public int UserId {get; set;}
        [Required(ErrorMessage = "you must have a username")]
        public string UserName {get; set;}
        public ICollection<Review> Reviews {get;}
    }
}