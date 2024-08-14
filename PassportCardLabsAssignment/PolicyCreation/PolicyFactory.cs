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
        public static Dictionary<PolicyType, PolicySettings> PolicyTypeToPolicySettings = new Dictionary<PolicyType, PolicySettings>()
        {
            [PolicyType.Health] = new PolicySettings(typeof(HealthPolicy), new HealthPolicyValidation()),
            [PolicyType.Life] = new PolicySettings(typeof(LifePolicy), new LifePolicyValidation()),
            [PolicyType.Travel] = new PolicySettings(typeof(TravelPolicy), new TravelPolicyValidation()),
        };

        public static IPolicy CreatePolicy(PolicyType policyType, string policyJson)
        {
            var policySettings = PolicyTypeToPolicySettings[policyType];
            var concretePolicy = JsonConvert.DeserializeObject(policyJson, policySettings.ConcretePropertyType, new StringEnumConverter());
            if (concretePolicy == null)
            {
                throw new PolicyNotFoundException();
            }
            IPolicy policy = concretePolicy as IPolicy;
            policy.PolicyValidation = policySettings.PolicyValidation;
            return policy;
        }


    }
    public class PolicySettings
    {
        public PolicySettings(Type concretePropertyType, IPolicyValidation policyValidation)
        {
            ConcretePropertyType = concretePropertyType;
            PolicyValidation = policyValidation;
        }

        public Type ConcretePropertyType { get; set; }

        public IPolicyValidation PolicyValidation { get; set; }
    }
}
