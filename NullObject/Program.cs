using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager(new NLogLogger());
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        private ILogger logger;
        public CustomerManager(ILogger _logger)
        {
            logger = _logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With Log4Net");
        }
    }

    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With NLog");

        }
    }

    class StubLogger : ILogger
    {

        //Sİngleton :D

        private static StubLogger stubLogger;
        private static object _lock = new object();

        private StubLogger()
        {
                
        }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (stubLogger == null)
                {
                    stubLogger = new StubLogger();
                }

            }

            return stubLogger;
        }
        public void Log()
        {
            
        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }


}
