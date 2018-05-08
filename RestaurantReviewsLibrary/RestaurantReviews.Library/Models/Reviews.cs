using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Library
{
    public class Reviews : IReviews
    { 
        public string Reviewer { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public int RestaurantId { get; set; }
        public override string ToString()
        {
            return $"\nRating: {Rating}\n {Reviewer}: {Comment}\n";          
        }
    }
}
