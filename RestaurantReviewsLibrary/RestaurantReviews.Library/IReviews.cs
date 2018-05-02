using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    interface IReviews
    {
        string Reviewer { get; set; }
        string Comment { get; set; }
        double Rating { get; set; }
    }
}
