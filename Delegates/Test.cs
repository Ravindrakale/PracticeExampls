using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class MathOperatios
    {
        public static double MultipleByTwo(double value)
        {
            return value * 2;
        }
        public static double Square(double value)
        {
            return value * value;
        }
    }

    class Test
    {
        public delegate double DoubleOp(double x);
        static void Main(string[] args)
        {
            DoubleOp[] operations = {
                                        MathOperatios.MultipleByTwo,
                                        MathOperatios.Square
                                    };
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("Using operations [{0}]", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                ProcessAndDisplayNumber(operations[i], 25);
            }
            Console.ReadKey();
        }
        static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            double result = action(value);
            Console.WriteLine("Value is {0}, result of operations is {1}", value, result);
        }
    }
}
