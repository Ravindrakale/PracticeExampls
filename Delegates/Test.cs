using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Currency
    {
        public uint Dollars;
        public ushort Cents;
        public Currency(uint dollars, ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }
        public override string ToString()
        {
            return string.Format("${0}.{1,-2:00}", Dollars, Cents);
        }
        public static string GetCurrencyUnit()
        {
            return "Doller";
        }
        public static explicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }

        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }
        public static implicit operator Currency(uint value)
        {
            return new Currency(value, 0);
        }
        public static implicit operator uint(Currency value)
        {
            return value.Dollars;
        }
    }
    class Test
    {
        public delegate string GetAString();
        static void Main(string[] args)
        {
            int x = 40;
            GetAString fsm = x.ToString;
            Console.WriteLine("String is {0}", fsm());
            Currency balance = new Currency(34, 50);
            fsm = balance.ToString;
            Console.WriteLine("String is {0}", fsm());
            fsm = new GetAString(Currency.GetCurrencyUnit);
            Console.WriteLine("String is {0}", fsm());
            Currency cur = (uint)55;
            Console.WriteLine(cur.ToString());
            Console.ReadKey();
        }
    }
}
