using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.Policy
{
    public class PolicyFactory
    {
        public static Dictionary<PolicyType, Type> PolicyTypeToPolicy = new Dictionary<PolicyType, Type>()
        {
            [PolicyType.Health] = typeof(HealthPolicy),
            [PolicyType.Life] = typeof(LifeInsurancePolicy),
            [PolicyType.Travel] = typeof(TravelPolicy)
        };
        public static IPolicy CreatePolicy(PolicyType policyType, string policyJson)
        {
            var concretePolicyType = PolicyTypeToPolicy[policyType];
            var concretePolicy = JsonConvert.DeserializeObject(policyJson, concretePolicyType);
            if (concretePolicy == null)
            {
                throw new PolicyNotFoundException();
            }
            return concretePolicy as IPolicy;
        }

    }
}
