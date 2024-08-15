using PassportCardLabsAssignment.Policy;
using PassportCardLabsAssignment.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment
{
    public class HealthPolicyValidation : IPolicyValidation
    {
        public HealthPolicyValidation()
        {
            ValidationErrors = new List<string>();
        }

        public List<string> ValidationErrors { get; set; }

        public bool IsValidPolicy(IPolicy policy)
        {
            var healthPolicy = policy as HealthPolicy;
            string errorMessage = "";
            if (String.IsNullOrEmpty(healthPolicy.Gender))
            {
                errorMessage = "Health policy must specify Gender";
                Console.WriteLine(errorMessage);
                ValidationErrors.Add(errorMessage);
            }
            return !ValidationErrors.Any();
        }
    }
}
