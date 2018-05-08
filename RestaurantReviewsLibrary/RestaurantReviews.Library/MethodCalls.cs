using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public static class MethodCalls
    {
        public static List<Restaurant> rest = new List<Restaurant>();
        public static List<Restaurant> newList = new List<Restaurant>();
        public static List<Reviews> rev = new List<Reviews>();
        public static Restaurant singleRest = new Restaurant();
        public static void SetLibRest()
        {
            rest = DLAccessor.GetLibRestaurants();
        }

        /*public static void Topthree()
        {
            /*if(rest == null)
            {
               //Serializer.SetList();
            }
        newList = Sort.AvgRatingSort(rest);
            for (int i = 0; i< 3; i++)
                Console.WriteLine(newList.ElementAt(i).Name + " Rating: " + newList.ElementAt(i).AvgRating);
        }*/
        public static List<Restaurant> TopThree()
        {
            List<Restaurant> returnList = new List<Restaurant>();
            newList = Sort.AvgRatingSort(rest);
            for (int i = 0; i < 3; i++)
                returnList.Add(newList.ElementAt(i));
            return returnList;
        }
        public static void ChooseSort(int x)
        {
            /*if (rest == null)
            {
                //Serializer.SetList();
            }*/
            if (x == 1)
                newList = Sort.AlphabeticalSort(rest);
            if (x == 2)
                newList = Sort.AlphabeticalReverseSort(rest);
            if (x == 3)
                newList = Sort.StringSizeSort(rest);
            if (x == 4)
                newList = Sort.AvgRatingSort(rest);
            foreach (var i in newList)
                Console.WriteLine(i.Name);
        }
        public static void ReturnRestByName(string name)
        {
            /*if (rest == null)
            {
                //Serializer.SetList();
            }*/
            newList = PrintRestaurant.PrintRestaurantByName(rest, name);
            foreach (var restList in newList)
                Console.WriteLine(restList.ToString());
        }
        public static void ReturnRestById(int id)
        {
            /*if (rest == null)
            {
                //Serializer.SetList();
            }*/
            singleRest = PrintRestaurant.PrintRestaurantById(rest, id);
            Console.WriteLine(singleRest.ToString());
        }
        public static void GetReviewsByName(string name)
        {
            /*if (rest == null)
            {
                //Serializer.SetList();
            }*/
            newList = PrintRestaurant.PrintReviews(rest, name);
            foreach (var member in newList)
                Console.WriteLine(member.reviews.ToString());
        }
        public static void MCReviewsById(int id)
        {
            /*if (rest == null)
            {
                //Serializer.SetList();
            }*/
            rev = PrintRestaurant.PrintReviewsById(rest, id);
            foreach (var member in newList)
                foreach (var i in member.reviews)
                    Console.WriteLine(i.ToString());
        }
        /*public static void searchRestName(string sub)
        {
            /*if (rest == null)
            {
               //Serializer.SetList();
            }
            newList = Search.Lookup(rest, sub);
            foreach (var name in newList)
                Console.WriteLine(name.Name);
        }*/
        public static List<Restaurant> SearchRestName(string sub)
        {
            newList = Search.Lookup(rest, sub);
            return newList;
        }
        public static Restaurant GetRestById(int id)
        {
            return PrintRestaurant.PrintRestaurantById(rest, id);
        }
        public static void AddRestaurantToDb(Restaurant rest)
        {
            rest.ID = 90;
            DLAccessor.AddRestToDb(rest);
        }
        public static void AddReviewToDb(Reviews rev)
        {
            DLAccessor.AddReviewToDb(rev);
        }
        public static void UpdateRest(Restaurant rest)
        {
            DLAccessor.UpdateRestaurant(rest);
        }
        public static void UpdateRev(Reviews rev)
        {
            DLAccessor.UpdateReview(rev);
        }
        public static void DeleteRest(int id)
        {
            DLAccessor.DeleteRestaurant(id);
        }
        public static void DeleteRev(int id)
        {
            DLAccessor.DeleteReview(id);
        }
    }
}
