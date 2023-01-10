using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAllExpressionsInBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var expression = "1 + (2 - (2 + 2) * 4 / (3 + 1)) * 5";
            var stack = new Stack<int>();
            

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    var start = stack.Peek();
                    var end = i + 1;
                    var length = end - start;
                    Console.WriteLine(expression.Substring(start, length));
                    stack.Pop();
                }
            }
        }
    }
}
