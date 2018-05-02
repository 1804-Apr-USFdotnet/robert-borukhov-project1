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
    public class SortTests
    {
        [TestMethod()]
        public void AlphabeticalSortTest()
        {
            MethodCalls.SetLibRest();
            string expected = "Applebee's";
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.Sort.AlphabeticalSort(test1);
            Assert.AreEqual(expected, actual.ElementAt(0).Name);
        }

        [TestMethod()]
        public void AlphabeticalReverseSortTest()
        {
            MethodCalls.SetLibRest();
            string expected = "Wendy's";
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.Sort.AlphabeticalReverseSort(test1);
            Assert.AreEqual(expected, actual.ElementAt(0).Name);
        }

        [TestMethod()]
        public void StringSizeSortTest()
        {
            MethodCalls.SetLibRest();
            string expected = "Wendy's";
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.Sort.StringSizeSort(test1);
            Assert.AreEqual(expected, actual.ElementAt(0).Name);
        }

        [TestMethod()]
        public void AvgRatingSortTest()
        {
            MethodCalls.SetLibRest();
            string expected = "Martha's Bakery";
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.Sort.AvgRatingSort(test1);
            Assert.AreEqual(expected, actual.ElementAt(0).Name);
        }
    }
}