using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.Policy
{
    public class LifeInsurancePolicy : IPolicy
    {
        public PolicyType Type { get; set; }
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
