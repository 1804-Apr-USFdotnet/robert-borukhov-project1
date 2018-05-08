using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Data
{
    public class DataAccessLayer
    {
        static RestaurantDBEntities1 rest = new RestaurantDBEntities1();
        public static IEnumerable<Restaurant> getRestaurants()
        {
            return rest.Restaurants.ToList();
        }
        public static IEnumerable<Review> getReviews()
        {
            return rest.Reviews.ToList();
        }
    }
}
