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
    public class LifePolicyRating : IPolicyRating
    {
        public decimal Rating { get ; set ; }

        public decimal RatePolicy(IPolicy policy)
        {
            var lifePolicy = policy as LifePolicy;
            decimal baseRate = GetBaseRate(lifePolicy);
            if (lifePolicy.IsSmoker)
            {
                Rating = baseRate * 2;
            }
            else
            {
                Rating = baseRate;
            }
            return Rating;
        }

        private static decimal GetBaseRate(LifePolicy? lifePolicy)
        {
            int age = DateTime.Today.Year - lifePolicy.DateOfBirth.Year;
            if (lifePolicy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < lifePolicy.DateOfBirth.Day ||
                DateTime.Today.Month < lifePolicy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = lifePolicy.Amount * age / 200;
            return baseRate;
        }
    }
}
