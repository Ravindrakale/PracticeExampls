using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Delegates
{
    class MyAttribute
    {
        [Obsolete("Plz user MyMethodNew", true)]
        public void myMethod()
        {
            Console.WriteLine("Old method");
        }
        public void MyMethodNew()
        {
            Console.WriteLine("New Method");
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    class CheckAttribute : Attribute
    {
        public int MaxLength { get; set; }
        public CheckAttribute()
        {

        }
    }
    class Customer
    {
        private string _CustCode;
        [Check(MaxLength = 10)]
        public string CustCode
        {
            get
            {
                return _CustCode;
            }
            set
            {
                _CustCode = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DisplayDefectTrack("Delegates");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        public static void DisplayDefectTrack(string lcAssembly)
        {
            Assembly loAssembly = Assembly.Load(lcAssembly);

            Type[] laTypes = loAssembly.GetTypes();

            foreach (Type loType in laTypes)
            {
                Console.WriteLine("*======================*");
                Console.WriteLine("TYPE:\t" + loType.ToString());
                Console.WriteLine("*=====================*");

                object[] laAttributes = loType.GetCustomAttributes(typeof(DefectTrackAttribute), false);

                if (laAttributes.Length > 0)
                    Console.WriteLine("\nMod/Fix Log:");

                foreach (Attribute loAtt in laAttributes)
                {
                    DefectTrackAttribute loDefectTrack = (DefectTrackAttribute)loAtt;

                    Console.WriteLine("----------------------");
                    Console.WriteLine("Defect ID:\t" + loDefectTrack.DefectID);
                    Console.WriteLine("Date:\t\t" + loDefectTrack.ModificationDate);
                    Console.WriteLine("Developer ID:\t" + loDefectTrack.DeveloperID);
                    Console.WriteLine("Origin:\t\t" + loDefectTrack.Origin);
                    Console.WriteLine("Comment:\n" + loDefectTrack.FixComment);
                }

                MethodInfo[] laMethods = loType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                if (laMethods.Length > 0)
                {
                    Console.WriteLine("\nMethods: ");
                    Console.WriteLine("----------------------");
                }

                foreach (MethodInfo loMethod in laMethods)
                {
                    Console.WriteLine("\n\t" +
                      loMethod.ToString());

                    object[] laMethodAttributes = loMethod.GetCustomAttributes(typeof(DefectTrackAttribute), false);

                    if (laMethodAttributes.Length > 0)
                        Console.WriteLine("\n\t\tMod/Fix Log:");

                    foreach (Attribute loAtt in laMethodAttributes)
                    {
                        DefectTrackAttribute loDefectTrack = (DefectTrackAttribute)loAtt;
                        Console.WriteLine("\t\t----------------");
                        Console.WriteLine("\t\tDefect ID:\t" + loDefectTrack.DefectID);
                        Console.WriteLine("\t\tDeveloper ID:\t" + loDefectTrack.DeveloperID);
                        Console.WriteLine("\t\tOrigin:\t\t" + loDefectTrack.Origin);
                        Console.WriteLine("\t\tComment:\n\t\t" + loDefectTrack.FixComment);
                    }
                }
                Console.WriteLine("\n\n");
            }
            /*Customer cust = new Customer();
             Customer cust1 = new Customer();
             cust.CustCode = "123";
             cust.CustCode = "123456778";
             Type objType = cust.GetType();
             foreach (PropertyInfo p in objType.GetProperties())
             {
                 foreach (Attribute a in p.GetCustomAttributes(false))
                 {
                     CheckAttribute c = (CheckAttribute)a;
                     if (p.Name == "CustCode")
                     {
                         if (cust.CustCode.Length > c.MaxLength)
                         {
                             throw new Exception("Max Length Issue");
                         }
                     }
                 }
             }
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);
         }*/
        }
    }
}
