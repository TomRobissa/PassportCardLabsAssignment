using PassportCardLabsAssignment.PolicyRating;

namespace PassportCardLabsAssignment.Policy
{
    public class PolicyCreationSettings
    {
        public PolicyCreationSettings(Type concretePropertyType, IPolicyValidation policyValidation, IPolicyRating policyRating)
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
