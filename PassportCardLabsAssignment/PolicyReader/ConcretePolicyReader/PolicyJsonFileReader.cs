using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.PolicyReader
{
    public class PolicyJsonFileReader : IPolicyFileReader
    {
        public string PolicyFilePath { get; set; }

        public PolicyJsonFileReader(string policeFilePath)
        {
            if (string.IsNullOrEmpty(policeFilePath))
            {
                throw new ArgumentNullException(nameof(policeFilePath));
            }
            PolicyFilePath = policeFilePath;
        }

        public Tuple<PolicyType,string> ReadPolicy() //TODO: double serialization in ctor, should be dynamic
        {
            string policyJson = File.ReadAllText(PolicyFilePath);
            dynamic policy = JsonConvert.DeserializeObject<dynamic>(policyJson); //TODO: maybe serialize to IPolicy instead of dynamic, duplicate in factory
            if (policy == null)
            {
                Console.WriteLine("Failed to parse policy settings");
                throw new PolicyNotFoundException();
            }
           
            if (!Enum.TryParse(typeof(PolicyType), policy.type.ToString(), true, out object result))
            {
                Console.WriteLine($"expected valid policy type, received {policy.type}");
                throw new PolicyNotFoundException();
            }
            return Tuple.Create((PolicyType)result, policyJson);
        }
    }
}
