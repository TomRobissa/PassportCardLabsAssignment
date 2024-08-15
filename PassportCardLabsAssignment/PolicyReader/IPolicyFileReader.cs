using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardLabsAssignment.PolicyReader
{
    public interface IPolicyFileReader : IPolicyReader
    {
        public string PolicyFilePath { get; set; }
    }
}
