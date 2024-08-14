using PassportCardLabsAssignment.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.Policy
{
    public class LifePolicyValidation : IPolicyValidation
    {
        public LifePolicyValidation()
        {
            ValidationErrors = new List<string>();
        }

        public List<string> ValidationErrors { get; set; }

        public bool IsValidPolicy(IPolicy policy)
        {
            var lifePolicy = policy as LifePolicy;
            string errorMessage = "";
            if (lifePolicy.DateOfBirth == DateTime.MinValue)
            {
                errorMessage = "Life policy must include Date of Birth.";
                Console.WriteLine(errorMessage);
                ValidationErrors.Add(errorMessage);
            }
            if (lifePolicy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                errorMessage = "Max eligible age for coverage is 100 years.";
                Console.WriteLine(errorMessage);
                ValidationErrors.Add(errorMessage);
            }
            if (lifePolicy.Amount == 0)
            {
                errorMessage = "Life policy must include an Amount.";
                Console.WriteLine(errorMessage);
                ValidationErrors.Add(errorMessage);
            }
            return !ValidationErrors.Any();
        }
    }
}
