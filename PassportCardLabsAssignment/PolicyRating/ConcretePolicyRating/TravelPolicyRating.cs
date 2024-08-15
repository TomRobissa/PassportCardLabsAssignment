using Newtonsoft.Json;
using PassportCardLabsAssignment.Policy;
using PassportCardLabsAssignment.PolicyRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.Policy
{
    public class TravelPolicyRating : IPolicyRating
    {
        public decimal Rating { get ; set ; }

        public decimal RatePolicy(IPolicy policy)
        {
            var travelPolicy = policy as TravelPolicy;
            Rating = travelPolicy.Days * 2.5m;
            if (travelPolicy.Country == "Italy")
            {
                Rating *= 3;
            }
            return Rating;  
        }
    }
}
