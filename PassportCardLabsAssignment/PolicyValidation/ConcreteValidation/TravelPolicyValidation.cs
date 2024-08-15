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
    public class TravelPolicyValidation : IPolicyValidation
    {
        public TravelPolicyValidation()
        {
            ValidationErrors = new List<string>();
        }
        public List<string> ValidationErrors { get; set; }

        public bool IsValidPolicy(IPolicy policy)
        {
            var travelPolicy = policy as TravelPolicy;
            string errorMessage = "";
            if (travelPolicy.Days <= 0)
            {
                errorMessage = "Travel policy must specify Days.";
                Console.WriteLine(errorMessage);
                ValidationErrors.Add(errorMessage);
            }
            if (travelPolicy.Days > 180)
            {
                errorMessage = "Travel policy cannot be more then 180 Days.";
                Console.WriteLine(errorMessage);
                ValidationErrors.Add(errorMessage);
            }
            if (String.IsNullOrEmpty(travelPolicy.Country))
            {
                errorMessage = "Travel policy must specify country.";
                Console.WriteLine(errorMessage);
                ValidationErrors.Add(errorMessage);
            }
            return !ValidationErrors.Any();
        }
    }
}
