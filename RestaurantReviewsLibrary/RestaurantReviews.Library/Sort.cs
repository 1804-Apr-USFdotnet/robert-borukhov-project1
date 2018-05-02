using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public class Sort
    {
        public static List<Restaurant> AlphabeticalSort(List<Restaurant> rest)
        {
            return rest.OrderBy(x => x.Name).ToList();
        }
        public static List<Restaurant> AlphabeticalReverseSort(List<Restaurant> rest)
        {
            return rest.OrderByDescending(x => x.Name).ToList();
        }
        public static List<Restaurant> StringSizeSort(List<Restaurant> rest)
        {
            var length = from element in rest
                         orderby element.Name.Length
                         select element;
            return length.ToList();
        }
        public static List<Restaurant> AvgRatingSort(List<Restaurant> rest)
        {
            return rest.OrderByDescending(x => x.AvgRating).ToList();
        }
    }
}
