using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    interface IRestaurant
    {
        string Name { get; set; }
        string Address { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string State { get; set; }
        int Zip { get; set; }
    }
}
