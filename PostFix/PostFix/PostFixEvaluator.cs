using System.Collections;
using Microsoft.VisualBasic;

namespace PostFix
{
    public class PostFixEvaluator
    {
        public int Evaluate(string postFix)
        {
            var tokens = new Stack();
            var rawTokens = postFix.Split(' ');
            foreach (var token in rawTokens)
            {
                if (long.TryParse(token, out long operand))
                {
                    tokens.Push(operand);
                }
                else
                {
                    var o1 = Convert.ToDouble(tokens.Pop());
                    var o2 = Convert.ToDouble(tokens.Pop());
                    tokens.Push(Calculate(o2, o1, token));
                }
            }
            return Convert.ToInt32(tokens.Pop());
        }

        private Double Calculate(double o2, double o1, string op)
        {
            switch (op)
            {
                case "+":
                    return o2 + o1;
                case "-":
                    return o2 - o1;
                case "*":
                    return o2 * o1;
                case "/":
                    return o2 / o1;
                default:
                    return 0;

            }
        }
    }
}