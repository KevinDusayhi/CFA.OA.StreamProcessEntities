using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFA.OA.StreamProcessEntities;

namespace CFA.OA.StreamProcessServices
{
    public class ParseService : IParseService
    {
        
        public ParseService()
        {

        }
        public int ParseToScore(string s)
        {
            if (s == null || s.Length == 0) return 0;
            Stack<Char> stack = new Stack<char>();
            char[] C = s.ToCharArray();
            int flag = 0;
            int sum = 0;

            for (int i = 0; i < s.Length;i++)
            {
                if (C[i] == '<') flag = 1;
                else if (C[i] == '>') flag = 0;
                else if (C[i] == '!') i++;
                else if (C[i] == '{' && flag == 0)
                {
                    stack.Push(C[i]);
                }
                else if (C[i] == '}' && flag == 0)
                {
                    sum += stack.Count;
                    stack.Pop();

                }
                
            }
            if (flag == 1 || stack.Count > 0)
            {
                throw new Exception("Invalid Input");
            }
            return sum;
        }
    }
}
