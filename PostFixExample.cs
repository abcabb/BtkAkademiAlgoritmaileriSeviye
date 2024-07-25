using DataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtkAkademiAlgoritmaileriSeviye
{
    public class PostFixExample
    {
        private string expression;
        DataStructures.Stack.Stack<string> S = 
            new DataStructures.Stack.Stack<string>(StackType.Array);

        private string Expression()
        {
            int val1, val2, answer;
            for(int i=0; i<expression.Length; i++)
            {
                string c = expression.Substring(i,1);
                if(c == "*")
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    answer = val2 * val1;
                    S.Push(answer.ToString());
                }
                else if(c == "+")
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    answer = val2 + val1;
                    S.Push(answer.ToString());
                }
                else if( c == "-")
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    answer = val2 - val1;
                    S.Push(answer.ToString());
                }
                else if(c == "/")
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    answer = val2 / val1;
                    S.Push(answer.ToString());
                }
                else
                {
                    S.Push(c);
                }
            }
            return S.Pop();
        }

        public static string Run(string expression)
        {
            PostFixExample e = new PostFixExample();
            e.expression = expression;
            return e.Expression();
        }
    }
}
