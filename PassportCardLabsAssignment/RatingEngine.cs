using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PassportCardLabsAssignment.Policy;
using PassportCardLabsAssignment.PolicyReader;
using System;
using System.IO;

namespace TestRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        public void Rate()
        {
            Console.WriteLine("Starting rate.");
            Console.WriteLine("Loading policy.");

            // load policy - open file policy.json
            IPolicyFileReader policyFileReader = new PolicyJsonFileReader("policy.json");
            var policyTypeAndPolicy = policyFileReader.ReadPolicy();

            IPolicy policy = PolicyFactory.CreatePolicy(policyTypeAndPolicy.Item1, policyTypeAndPolicy.Item2);

            Console.WriteLine($"Validating {Enum.GetName(policy.Type)} policy.");
            if (!policy.IsValid)
            {
                return;
            }

            Console.WriteLine($"Rating {Enum.GetName(policy.Type)} policy...");
            Rating = policy.Rating;

            Console.WriteLine("Rating completed.");
        }

    }
}
