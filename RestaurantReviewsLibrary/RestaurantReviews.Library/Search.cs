using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public static class Search
    {
        public static List<Restaurant> Lookup(List<Restaurant> restaurants, string sub)
        {
            List<Restaurant> newList = new List<Restaurant>();
            foreach (var one in restaurants)
            {
                if (one.Name.ToLower().Contains(sub.ToLower()))
                    newList.Add(one);
            }
            return newList;
        }
    }
}
