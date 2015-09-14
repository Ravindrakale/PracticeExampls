using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Math
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
    class Test
    {
        public delegate int CalculationHandler(int x, int y);
        static void Main(string[] args)
        {
            Math math = new Math();
            CalculationHandler sumHandler = new CalculationHandler(math.Sum);
            int result = sumHandler(12, 25);
            Console.WriteLine("Result is: " + result);
            Console.ReadKey();
        }
    }
}
