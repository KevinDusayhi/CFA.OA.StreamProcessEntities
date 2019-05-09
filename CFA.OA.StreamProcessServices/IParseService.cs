using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFA.OA.StreamProcessEntities;

namespace CFA.OA.StreamProcessServices
{
    public interface IParseService
    {
        //parse the input to group and calculate the score
        int ParseToScore(string s);
    }
}
