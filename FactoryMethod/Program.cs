using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new NLoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }


    }
    public class NLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }



    }

    public interface ILogger
    {
        void Log();
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With EdLogger");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log4NetLogger");
        }
    }


    public class CustomerManager
    {

        private ILoggerFactory loggerFactory;
        public CustomerManager(ILoggerFactory _loggerFactory)
        {
            loggerFactory = _loggerFactory;
        }
        
        public void Save()
        {
            Console.WriteLine("Saved");
            //ILogger logger = new EdLogger();//new yazılıyorsa o nesneyi bağımlı olursunuz
            //ILogger logger = new LoggerFactory().CreateLogger();
            ILogger logger = loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
