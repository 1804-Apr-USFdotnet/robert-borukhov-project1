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
    public class MethodCallsTests
    {
        [TestMethod()]
        public void SetLibRestTest()
        {
            //Arrange
            int expected = 10;
            //Act
            MethodCalls.SetLibRest();
            List<Restaurant> actual = MethodCalls.rest;
            //Assert
            Assert.AreEqual(expected,actual.Count());
        }
    }
}