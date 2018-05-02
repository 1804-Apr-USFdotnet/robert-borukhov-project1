using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Data;

namespace RestaurantReviews.Library
{
    static class DALAccessor
    {
        public static Restaurant pop = new Restaurant();
        public static Reviews singleRev = new Reviews();

        public static Reviews ImportReview(RestaurantReviews.Data.Review dlRev)
        {
            int revId = dlRev.RestaurantId;
            var libRev = new Reviews()
            {
                RestaurantId = dlRev.RestaurantId,
                Reviewer = dlRev.Reviewer,
                Comment = dlRev.Comment,
                Rating = dlRev.Rating
            };
            return libRev;
        }
        public static Review GetReviewById(int id)
        {
            Review miniRev;
            var dbRev = new RestaurantDBEntities();
            miniRev = dbRev.Reviews.Find(id);
            return miniRev;
        }
        public static IEnumerable<RestaurantReviews.Data.Review> GetReviewsByID(int restId)
        {
            IEnumerable<RestaurantReviews.Data.Review> reviewList;
            var dbRevs = new RestaurantDBEntities();
            reviewList = dbRevs.Reviews.Where(x => x.RestaurantId == restId).ToList();
            return reviewList;
        }
        public static List<Reviews> GetRevListById(int restId)
        {
            return GetReviewsByID(restId).Select(x => ImportReview(x)).ToList();
        }
        public static Restaurant SetRest(RestaurantReviews.Data.Restaurant dlRest)
        {
            int restId = dlRest.ID;
            List<Reviews> revList = GetRevListById(restId);
            var restModel = new Restaurant()
            {
                ID = dlRest.ID,
                Name = dlRest.Name,
                Address = dlRest.Address,
                Street = dlRest.Street,
                City = dlRest.City,
                State = dlRest.State,
                PhoneNumber = dlRest.PhoneNumber,
                Zip = (int)dlRest.Zip,
                reviews = revList
            };
            restModel.AvgRating = restModel.CalcAvgRating();
            return restModel;
        }
        public static IEnumerable<RestaurantReviews.Data.Restaurant> GetRestaurants()
        {
            IEnumerable<RestaurantReviews.Data.Restaurant> dlRest;
            var dbList = new RestaurantDBEntities();
            dlRest = dbList.Restaurants.ToList();
            return dlRest;
        }
        public static List<Restaurant> GetLibRestaurants()
        {
            return GetRestaurants().Select(x => SetRest(x)).ToList();
        }
    }
}
