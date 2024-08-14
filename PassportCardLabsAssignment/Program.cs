using PassportCardLabsAssignment.Policy;
using PassportCardLabsAssignment.PolicyReader;

namespace TestRating
{
    class Program
    {
        static void Main(string[] args)
        {
            IPolicyFileReader policyFileReader = new PolicyJsonFileReader("policy.json");
            var policyTypeAndPolicy = policyFileReader.ReadPolicy();
            IPolicy policy = PolicyFactory.CreatePolicy(policyTypeAndPolicy.Item1, policyTypeAndPolicy.Item2);
            if (!policy.IsValid)
            {
                return; 
            }
            Console.WriteLine($"Rating completed: rating is {policy.Rating}");
        }

        private static void PreviousMain()
        {
            Console.WriteLine("Insurance Rating System Starting...");

            var engine = new RatingEngine();
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }
        }

    }
}
