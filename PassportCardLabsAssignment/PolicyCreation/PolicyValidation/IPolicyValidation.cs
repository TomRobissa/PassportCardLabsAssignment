using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportCardLabsAssignment.Policy
{
    public interface IPolicyValidation
    {
        public List<string> ValidationErrors { get; }
        bool IsValidPolicy(IPolicy policy);
    }
}
