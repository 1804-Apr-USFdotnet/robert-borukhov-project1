using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantReviews.Web.Views.Models
{
    public class RestaurantProperties
    {
        public int ID;
        public List<RestaurantReviews.Library.Reviews> reviews;
        public RestaurantReviews.Library.Restaurant restaurant;
        public List<RestaurantReviews.Library.Restaurant> restList;

        public RestaurantProperties(int id)
        {
            ID = id;
            reviews = RestaurantReviews.Library.PrintRestaurant.PrintReviewsById(RestaurantReviews.Library.MethodCalls.rest, id);
            restaurant = RestaurantReviews.Library.PrintRestaurant.PrintRestaurantById(RestaurantReviews.Library.MethodCalls.rest, id);
        }
        
    }
}