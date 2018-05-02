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
    public class SearchTests
    {
        [TestMethod()]
        public void LookupTest()
        {
            MethodCalls.SetLibRest();
            int expected = 2;
            List<Restaurant> test1 = MethodCalls.rest;
            List<Restaurant> actual = RestaurantReviews.Library.Search.Lookup(test1, "ch");
            Assert.AreEqual(expected, actual.Count());
        }
    }
}