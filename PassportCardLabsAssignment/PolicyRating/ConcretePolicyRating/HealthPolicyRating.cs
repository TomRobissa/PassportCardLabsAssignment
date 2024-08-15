using PassportCardLabsAssignment.Policy;
using PassportCardLabsAssignment.Policy;
using PassportCardLabsAssignment.PolicyRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment
{
    public class HealthPolicyRating : IPolicyRating
    {
        public decimal Rating { get ; set; }

        public decimal RatePolicy(IPolicy policy)
        {
            var healthPolicy = policy as HealthPolicy;
            if (healthPolicy.Gender == "Male")
            {
                if (healthPolicy.Deductible < 500)
                {
                    Rating = 1000m;
                }
                else
                {
                    Rating = 900m;
                }
            }
            else
            {
                if (healthPolicy.Deductible < 800)
                {
                    Rating = 1100m;
                }
                else
                {
                    Rating = 1000m;
                }
            }
            return Rating;

        }
    }
}
