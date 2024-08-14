using Newtonsoft.Json;
using PassportCardLabsAssignment.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.Policy
{
    public class TravelPolicy : IPolicy
    {
        public PolicyType Type { get; set; }
        public IPolicyValidation PolicyValidation { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public int Days { get; set; }
    }
}
