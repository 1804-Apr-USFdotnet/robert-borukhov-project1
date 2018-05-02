using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace RestaurantReviews.Library
{
    public static class Serializer
    {
        static string location = Directory.GetCurrentDirectory() + @"\restaurantList.json";
        static string loc2 = Directory.GetCurrentDirectory() + @"\reviewList.json";

        public static void SetList()
        {
            RestaurantReviews.Library.MethodCalls.rest = Deserialize(System.IO.File.ReadAllText(location));
        }
        public static void SetReviewList()
        {
            RestaurantReviews.Library.MethodCalls.rev = DeserializeReviews(System.IO.File.ReadAllText(loc2));
        }

        public static void Serialize(List<Restaurant> rest)
        {
            string text = JsonConvert.SerializeObject(rest);
            System.IO.File.WriteAllText(location, text);
        }
        public static List<Restaurant> Deserialize(string text)
        {
            var rest = JsonConvert.DeserializeObject<List<Restaurant>>(text);
            return rest;
        }

        public static void SerializeReviews(List<Reviews> rev)
        {
            string text = JsonConvert.SerializeObject(rev);
            System.IO.File.WriteAllText(loc2, text);
        }
        public static List<Reviews> DeserializeReviews(string text)
        {
            var rev = JsonConvert.DeserializeObject<List<Reviews>>(text);
            return rev;
        }
    }
}
