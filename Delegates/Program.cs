using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    #region Event
    public class Boiler
    {
        private int temp;
        private int pressure;
        public Boiler(int t, int p)
        {
            temp = t;
            pressure = p;
        }
        public int getTemp()
        {
            return temp;
        }
        public int getPressure()
        {
            return pressure;
        }
    }

    //Event Publisher
    class DelegateBoilerEvent
    {
        public delegate void BoilerLogHandler(string status);
        public event BoilerLogHandler BoilerEventLog;
        public void LogProcess()
        {
            string remarks = "O. K";
            Boiler b = new Boiler(100, 12);
            int t = b.getTemp();
            int p = b.getPressure();
            if (t > 150 || t < 80 || p < 12 || p > 25)
            {
                remarks = "Need Maintenance";
            }
            OnBoilerEventLog("Logger info:\n");
            OnBoilerEventLog("Temparature: " + t + "\nPressure: " + p);
            OnBoilerEventLog("\nMessage: " + remarks);
        }
        protected void OnBoilerEventLog(string message)
        {
            if (BoilerEventLog != null)
            {
                BoilerEventLog(message);
            }
        }
    }

    class BoilerInfoLogger
    {
        FileStream fs;
        StreamWriter sw;
        public BoilerInfoLogger(string filename)
        {
            fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
        }
        public void Logger(string info)
        {
            sw.WriteLine(info);
        }
        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }
    //The Event Subscriber
    #endregion
    public class Event
    {
        public delegate void HandelMarkDel(string m);
        public event HandelMarkDel MarkEvent;
        public void setMark(int m1,int m2)
        {
            if (m1 > 100)
            {
                m1 = 0;
                if (MarkEvent != null)
                {
                    MarkEvent("Invalid Mark for sub 1!");
                }
            }
            else if (m2 > 100)
            {
                m2 = 0;
                if (MarkEvent != null)
                {
                    MarkEvent("Invalid Mark for sub 2!");
                }
            }
            Mark m = new Mark(m1, m2);
            m.displayMark();
        }
    }
    public class Mark
    {
        int m1, m2;
        public Mark(int m11, int m22)
        {
            
            m1 = m11;
            m2 = m22;
        }
        public void displayMark()
        {
            Console.WriteLine("Mark for M1:{0}\nMark for M2:{1}", m1, m2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Event e = new Event();
                e.MarkEvent += new Event.HandelMarkDel(Logger);
                e.setMark(456, 87);
                //BoilerInfoLogger filelog = new BoilerInfoLogger("G:\\Boiler.txt");
                //DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
                //boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(Logger);
                //boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(filelog.Logger);
                //boilerEvent.LogProcess();
                //filelog.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.ReadKey();
        }
        static void Logger(string info)
        {
            Console.WriteLine(info);
        }
    }
}
