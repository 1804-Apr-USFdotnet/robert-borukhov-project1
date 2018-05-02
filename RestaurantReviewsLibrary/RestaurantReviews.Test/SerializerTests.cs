using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace RestaurantReviews.Library.Tests
{
    [TestClass()]
    public class SerializerTests
    {
        [TestMethod()]
        public void DeserializeTest()
        {
            //Assign
            string text = Directory.GetCurrentDirectory() + @"\restaurantList.json";
            Restaurant r1 = new Restaurant()
            {
                Name = "McD",
                AvgRating = 7.8,
                Address = "87-15",
                Street = "Main St",
                City = "Miami",
                State = "FD",
                Zip = 95421,
                PhoneNumber = "5551793",
                ID = 1
            };
            //Act
            List<Restaurant> expected = new List<Restaurant>();
            expected.Add(r1);
            var actual = Serializer.Deserialize(System.IO.File.ReadAllText(text));
            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        
        [TestMethod()]
        public void DeserializeReviewsTest()
        {
            //Assign
            List<Reviews> expected = new List<Reviews>();
            string text = Directory.GetCurrentDirectory() + @"\reviewList.json";
            Reviews rev1 = new Reviews()
            {
                Reviewer = "Robert",
                Comment = "THey are excellent!",
                Rating = 8.3,
                RestaurantId = 1
            };
            Reviews rev2 = new Reviews()
            {
                Reviewer = "Tim",
                Comment = "They could be better.",
                Rating = 6.4,
                RestaurantId = 1
            };
            Reviews rev3 = new Reviews()
            {
                Reviewer = "Billy",
                Comment = "I'd rather eat somewhere else.",
                Rating = 4.7,
                RestaurantId = 1
            };
            //Act
            expected.Add(rev1);
            expected.Add(rev2);
            expected.Add(rev3);
            var actual = Serializer.DeserializeReviews(System.IO.File.ReadAllText(text));
            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}