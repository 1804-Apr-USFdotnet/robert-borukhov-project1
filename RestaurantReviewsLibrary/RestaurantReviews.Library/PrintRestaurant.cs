using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public static class PrintRestaurant
    {
        public static List<Restaurant> PrintRestaurantByName(List<Restaurant> rest, string text)
        {
            List<Restaurant> newList = new List<Restaurant>();
            text = text.ToLower();
            foreach (var list in rest)
                if ((list.Name.ToLower()) == text)
                    newList.Add(list);
            return newList;
        }
        public static List<Restaurant> PrintRestaurantById(List<Restaurant> rest, int id)
        {
            List<Restaurant> newList = new List<Restaurant>();
            foreach (var list in rest)
                if (list.ID == id)
                    newList.Add(list);
            return newList;
        }
        public static List<Restaurant> PrintReviews(List<Restaurant> rest, string text)
        {
            List<Restaurant> newList = new List<Restaurant>();
            text = text.ToLower();
            foreach (var list in rest)
                if ((list.Name.ToLower()) == text)
                    newList.Add(list);
            return newList;
        }
        public static List<Restaurant> PrintReviewsById(List<Restaurant> rest, int id)
        {
            List<Restaurant> newList = new List<Restaurant>();
            foreach (var list in rest)
                if (list.ID == id)
                    newList.Add(list);
            return newList;
        }
    }
}
