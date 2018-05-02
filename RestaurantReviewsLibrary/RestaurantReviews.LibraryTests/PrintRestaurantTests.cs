using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library.Tests
{
    [TestClass()]
    public class PrintRestaurantTests
    {
        [TestMethod()]
        public void PrintRestaurantByNameTest()
        {
            MethodCalls.SetLibRest();
            int expected = 2;
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.PrintRestaurant.PrintRestaurantByName(test1, "sh");
            Assert.AreEqual(expected,actual.Count());
        }

        [TestMethod()]
        public void PrintRestaurantByIdTest()
        {
            MethodCalls.SetLibRest();
            int expected = 1;
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.PrintRestaurant.PrintRestaurantById(test1, 2);
            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod()]
        public void PrintReviewsTest()
        {
            MethodCalls.SetLibRest();
            int expected = 3;
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.PrintRestaurant.PrintReviews(test1, "Subways");
            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod()]
        public void PrintReviewsByIdTest()
        {
            MethodCalls.SetLibRest();
            int expected = 3;
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.PrintRestaurant.PrintReviewsById(test1, 4);
            Assert.AreEqual(expected, actual.Count());
        }
    }
}