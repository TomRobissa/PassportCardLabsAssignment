using PassportCardLabsAssignment.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportCardLabsAssignment.PolicyRating
{
    internal interface IPolicyRating
    {
        public decimal RatePolicy(IPolicy policy);
    }
}
