using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public class Restaurant : IRestaurant
    {
        public string Name { get; set; }
        public double AvgRating { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string PhoneNumber { get; set; }
        public int ID { get; set; }
        public List<Reviews> reviews = new List<Reviews>();

        public double CalcAvgRating()
        {
            double size = reviews.Count();
            double sum = reviews.Sum(rating => rating.Rating);
            return AvgRating = sum / size;
        }
        public override String ToString()
        {
            return $"{ID} {Name}\n Address: {Address} {Street}, {City}, {State} {Zip} \n " +
                $"Phone Number: {PhoneNumber}";
        }

    }
}
