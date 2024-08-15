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
    public class HealthPolicy : IPolicy
    {
        public PolicyType Type { get; set; }
        public IPolicyValidation PolicyValidation { get; set; }
        public string FullName { get ; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public decimal Deductible { get; set; }
        public IPolicyRating PolicyRating { get; set; }
    }
}
