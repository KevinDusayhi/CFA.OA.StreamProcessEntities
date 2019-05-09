using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.OA.StreamProcessEntities
{
    public class InputParameter
    {
        public InputParameter(string s)
        {
            this.value = s;
        }
        public string value { get; set; }
    }
}
