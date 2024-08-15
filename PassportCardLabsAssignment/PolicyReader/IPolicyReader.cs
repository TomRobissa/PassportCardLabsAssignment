using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.PolicyReader
{
    public interface IPolicyReader
    {
        public Tuple<PolicyType, string> ReadPolicy();
    }
}
