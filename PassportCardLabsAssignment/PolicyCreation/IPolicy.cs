using PassportCardLabsAssignment.Policy;
using PassportCardLabsAssignment.PolicyRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.Policy
{
    public interface IPolicy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IPolicyValidation PolicyValidation { get; set; }
        public bool IsValid => PolicyValidation.IsValidPolicy(this);
        public IPolicyRating PolicyRating { get; set; }
        public decimal Rating => PolicyRating.RatePolicy(this);

    }
}
