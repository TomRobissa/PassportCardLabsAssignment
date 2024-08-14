using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;
using PassportCardLabsAssignment.Policy;

namespace PassportCardLabsAssignment.Policy
{
    public class PolicyFactory
    {
        public static Dictionary<PolicyType, PolicyCreationSettings> PolicyTypeToPolicySettings = new Dictionary<PolicyType, PolicyCreationSettings>()
        {
            [PolicyType.Health] = new PolicyCreationSettings(typeof(HealthPolicy), new HealthPolicyValidation(), new HealthPolicyRating()),
            [PolicyType.Life] = new PolicyCreationSettings(typeof(LifePolicy), new LifePolicyValidation(), new LifePolicyRating()),
            [PolicyType.Travel] = new PolicyCreationSettings(typeof(TravelPolicy), new TravelPolicyValidation(), new TravelPolicyRating()),
        };

        public static IPolicy CreatePolicy(PolicyType policyType, string policyJson)
        {
            var policySettings = PolicyTypeToPolicySettings[policyType];
            var concretePolicy = JsonConvert.DeserializeObject(policyJson, policySettings.ConcretePropertyType, new StringEnumConverter());
            if (concretePolicy == null)
            {
                throw new PolicyCreationException($"Failed to parse policy of type {Enum.GetName(policyType)}.");
            }
            IPolicy policy = concretePolicy as IPolicy;
            policy.PolicyValidation = policySettings.PolicyValidation;
            policy.PolicyRating = policySettings.PolicyRating;
            return policy;
        }


    }
}
