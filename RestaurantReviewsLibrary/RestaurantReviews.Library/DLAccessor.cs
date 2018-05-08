using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Data;

namespace RestaurantReviews.Library
{
    static class DLAccessor
    {
        public static Restaurant pop = new Restaurant();
        public static Reviews singleRev = new Reviews();

        //Read Reviews from database
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
        //Read restaraunt from database
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
        //Create a review
        public static void AddReviewToDb(Reviews rev)
        {
            var db = new RestaurantDBEntities();
            RestaurantReviews.Data.Review dbRev = new RestaurantReviews.Data.Review();
            dbRev.Reviewer = rev.Reviewer;
            dbRev.RestaurantId = rev.RestaurantId;
            dbRev.Comment = rev.Comment;
            dbRev.Rating = rev.Rating;
            db.Reviews.Add(dbRev);
            db.SaveChanges();
        }
        //Create a restaurant
        public static void AddRestToDb(Restaurant rest)
        {
            var db = new RestaurantDBEntities();
            RestaurantReviews.Data.Restaurant dbRest = new RestaurantReviews.Data.Restaurant();
            dbRest.Name = rest.Name;
            dbRest.Address = rest.Address;
            dbRest.Street = rest.Street;
            dbRest.City = rest.City;
            dbRest.State = rest.State;
            dbRest.Zip = rest.Zip;
            dbRest.PhoneNumber = rest.PhoneNumber;
            db.Restaurants.Add(dbRest);
            db.SaveChanges();
        }
        //Update a review
        public static void UpdateReview(Reviews rev)
        {
            var db = new RestaurantDBEntities();
            RestaurantReviews.Data.Review dbRev = db.Reviews.Find(rev.RestaurantId);
            dbRev.Comment = rev.Comment;
            dbRev.Rating = rev.Rating;
            dbRev.Reviewer = rev.Reviewer;
            db.SaveChanges();
        }
        //Update a restaurant
        public static void UpdateRestaurant(Restaurant rest)
        {
            var db = new RestaurantDBEntities();
            RestaurantReviews.Data.Restaurant dbRest = db.Restaurants.Find(rest.ID);
            dbRest.Name = rest.Name;
            dbRest.Address = rest.Address;
            dbRest.Street = rest.Street;
            dbRest.City = rest.City;
            dbRest.State = rest.State;
            dbRest.Zip = rest.Zip;
            dbRest.PhoneNumber = rest.PhoneNumber;
            db.SaveChanges();
        }
        //Delete a review
        public static void DeleteReview(int id)
        {
            var db = new RestaurantDBEntities();
            RestaurantReviews.Data.Review dlRev = db.Reviews.Find(id);
            db.Reviews.Remove(dlRev);
            db.SaveChanges();
        }
        //Delete a restaurant
        public static void DeleteRestaurant(int id)
        {
            var db = new RestaurantDBEntities();
            RestaurantReviews.Data.Restaurant dlRest = db.Restaurants.Find(id);
            db.Restaurants.Remove(dlRest);
            db.SaveChanges();
        }
    }
}
