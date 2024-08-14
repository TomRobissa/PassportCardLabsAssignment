using Newtonsoft.Json;
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
        public TravelPolicy()
        {
            Console.WriteLine("Empty ctor");
        }
        public PolicyType Type { get; set; }
        public string Country { get; set; }
        public int Days { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
