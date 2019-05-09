using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.OA.StreamProcessEntities
{
    public class OutputContent
    {
        public OutputContent(int s)
        {
            this.score = s;
        }
        public int score { get; set; }
    }
}
