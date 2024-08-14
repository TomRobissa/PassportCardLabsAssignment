using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;
using PassportCardLabsAssignment.Policy;
using PassportCardLabsAssignment.PolicyRating;

namespace PassportCardLabsAssignment.Policy
{
    public class PolicyFactory
    {
        public static Dictionary<PolicyType, PolicySettings> PolicyTypeToPolicySettings = new Dictionary<PolicyType, PolicySettings>()
        {
            [PolicyType.Health] = new PolicySettings(typeof(HealthPolicy), new HealthPolicyValidation(), new HealthPolicyRating()),
            [PolicyType.Life] = new PolicySettings(typeof(LifePolicy), new LifePolicyValidation(), new LifePolicyRating()),
            [PolicyType.Travel] = new PolicySettings(typeof(TravelPolicy), new TravelPolicyValidation(), new TravelPolicyRating()),
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
            policy.PolicyRating = policySettings.PolicyRating;
            return policy;
        }


    }
    public class PolicySettings
    {
        public PolicySettings(Type concretePropertyType, IPolicyValidation policyValidation, IPolicyRating policyRating)
        {
            ConcretePropertyType = concretePropertyType;
            PolicyValidation = policyValidation;
            PolicyRating = policyRating;
        }

        public Type ConcretePropertyType { get; set; }

        public IPolicyValidation PolicyValidation { get; set; }

        public IPolicyRating PolicyRating { get; set; }
    }
}
