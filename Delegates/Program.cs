using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Delegates
{
    public class MyClass
    {
        public virtual int AddNumb(int a, int b)
        {
            int result = a + b; 
            return result;
        }
    }
    class Class1
    {
        public int AddNumb(int n1, int n2)
        {
            return n1 + n2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nReflection.MethodInfo");
                Type tObj = typeof(Class1);
                object obj = Activator.CreateInstance(tObj);
                object [] mparam = new object[]{45,52};
                var res = tObj.InvokeMember("AddNumb", BindingFlags.InvokeMethod, null, obj, mparam);
                Console.WriteLine("Resutl: " + res);
                /*MyClass myClassObj = new MyClass();
                Type myTypeObj = typeof(MyClass);//myClassObj.GetType();
                MethodInfo myMethodInfo = myTypeObj.GetMethod("AddNumb");
                object[] mParam = new object[] { 5, 10 };
                var fullname = myTypeObj.FullName;
                var returnVal = myMethodInfo.Invoke(myClassObj, mParam);
                Console.WriteLine("\nFirst method -" + fullname + "\nreturns " + returnVal + "\n");*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
